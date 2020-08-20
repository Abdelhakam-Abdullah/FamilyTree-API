using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.DTOs;
using FamilyTreeApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FamilyTreeApi.Controllers.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepo _newsRepo;
        private readonly IUtitlities _utitlities;
        private readonly INewsImageRepo _newsImageRepo;
        private readonly IUploaderRepo _uploaderRepo;
        private IHostingEnvironment _hostingEnvironment;
        private IHubContext<SignalService> _hubContext;

        public NewsController(INewsRepo NewsRepo, IUtitlities utitlities,
            INewsImageRepo newsImage, IUploaderRepo uploaderRepo,
            IHostingEnvironment HostingEnvironment,
            IHubContext<SignalService> hubContext)
        {
            _newsRepo = NewsRepo;
            _utitlities = utitlities;
            _newsImageRepo = newsImage;
            _uploaderRepo = uploaderRepo;
            _hostingEnvironment = HostingEnvironment;
            _hubContext = hubContext;
        }
       
        //Get Latest News
        [AllowAnonymous]
        [HttpGet("getLatestNews")]
        public async Task<IActionResult> GetLatestNews(int pageNo = 1)
        {
            var result = await _newsRepo.GetLatestNews("M", pageNo);
            return Ok(result);
        }

        //Get News By News Type
        [AllowAnonymous]
        [HttpGet("getNewsByNewsType/{id}")]
        public async Task<IActionResult> GetNewsByNewsType(int id, int pageNo = 1)
        {
            var result = await _newsRepo.GetNewsByNewsType(id, pageNo);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("getNewsType")]
        public async Task<IActionResult> GetNewsType()
        {
            var result = await _newsRepo.GetNewsType();
            return Ok(result);
        }

        //Get News Details
        [AllowAnonymous]
        [HttpGet("getNewsDetails/{id}")]
        public async Task<IActionResult> GetNewsDetails(int id)
        {
            var result = await _newsRepo.GetNewsDetails(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        //Get News Images
        [AllowAnonymous]
        [HttpGet("getNewsImages/{id}")]
        public async Task<IActionResult> GetNewsImages(int id)
        {
            var result = await _newsRepo.GetNewsImages(id);
            return Ok(result);
        }

        //==============================================================
        [AllowAnonymous]
        [HttpPost("addNews")]
        public async Task<IActionResult> AddNews(NewsOperDTO news)
        {
            try
            {
                bool finalResult = false;
                
                news.CreatedDateM = DateTime.UtcNow.AddHours(3);
                news.CreatedDateH = Convert.ToDateTime(_utitlities.ToHijri(news.CreatedDateM));
                news.IsAccepted = null;

                var newNews = await _newsRepo.AddNews(news);
                if (newNews.Id > 0)
                {
                    await _hubContext.Clients.All.SendAsync("getData", newNews);

                    if (news.NewsImages.Count > 0)
                    {
                        foreach (var image in news.NewsImages)
                        {
                            image.CreatedDateM = DateTime.UtcNow.AddHours(3);
                            image.CreatedDateH = Convert.ToDateTime(_utitlities.ToHijri(image.CreatedDateM));
                            image.NewsId = newNews.Id;

                            finalResult = await _newsImageRepo.AddNewsImage(image);
                        }

                        if (finalResult)
                            return Ok();
                        return BadRequest();
                    }
                    else
                    {
                        return Ok();
                    }
                }
                return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [AllowAnonymous]
        [HttpPost("setImageMain")]
        public async Task<IActionResult> SetMainImage(NewsImageDTO newsImage)
        {
            try
            {
                //set current image main = 0
                var result = await _newsRepo.UpdateImags(newsImage);
                if (result)
                {
                    //set new image main = 1
                    var result2 = await _newsRepo.SetImageMain(newsImage.Id);
                    if (result)
                        return Ok();
                    return BadRequest();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [AllowAnonymous]
        [HttpPost("deleteImage")]
        public async Task<IActionResult> DeleteImage(NewsImageDTO newsImag)
        {
            try
            {
                var result = await _newsRepo.DeleteImage(newsImag.Id);
                if (result)
                {
                    _uploaderRepo.DeleteFiles(newsImag.ImagePath, "NewImags", _hostingEnvironment);
                    return Ok();
                }
                  

                return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [AllowAnonymous]
        [HttpGet("deleteNews/{id}")]
        public async Task<IActionResult> DeleteNews(int id)
        {
            try
            {
                var result = await _newsRepo.DeleteNews(id);
                if (result)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        //=========== test
        //[AllowAnonymous]
        //[HttpPost("addNewsss")]
        //public async Task<IActionResult> AddNewsss(NewsOperDTO news)
        //{
        //    try
        //    {
        //        news.CreatedDateM = DateTime.UtcNow.AddHours(3);
        //        news.CreatedDateH = Convert.ToDateTime(_utitlities.ToHijri(news.CreatedDateM));
        //        news.IsAccepted = null;

        //        var userAdded = await _newsRepo.AddNews(news);
        //        if (userAdded != null)
        //        {
        //            Response.Headers.Add("content-Type","text/event-stream");
        //            string message = "news has added";
        //            byte[] messageByte = ASCIIEncoding.ASCII.GetBytes(message);
        //            await Response.Body.WriteAsync(messageByte, 0, messageByte.Length);
        //            await Response.Body.FlushAsync();
        //        }
        //        return BadRequest();
        //    }
        //    catch (Exception ex) { return BadRequest(ex); }
        //}

        //[AllowAnonymous]
        //[HttpPost("updateNews")]
        //public async Task<IActionResult> UpdateNews(NewsOperDTO news)
        //{
        //    try
        //    {
        //        bool finalResult = false;
        //        var result = await _newsRepo.UpdateNews(news);
        //        if (result)
        //        {
        //            var userId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
        //            if (news.NewsImages.Count > 0)
        //            {
        //                foreach (var image in news.NewsImages)
        //                {
        //                    if (image.NewsId == 0)
        //                    {
        //                        image.CreatedDateM = DateTime.UtcNow.AddHours(3);
        //                        image.CreatedDateH = Convert.ToDateTime(_utitlities.ToHijri(image.CreatedDateM));
        //                        image.NewsId = news.Id;
        //                        finalResult = await _newsImageRepo.AddNewsImage(image);
        //                    }
        //                    else
        //                    {
        //                        finalResult = true;
        //                    }
        //                }

        //                if (finalResult)
        //                    return Ok();
        //                return BadRequest();
        //            }
        //            else
        //            {
        //                return Ok();
        //            }
        //        }
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}
    }
}