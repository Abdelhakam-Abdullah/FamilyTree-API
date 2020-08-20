using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.DTOs;
using FamilyTreeApi.Helpers;
using FamilyTreeApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FamilyTreeApi.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepo _newsRepo;
        private readonly IUtitlities _utitlities;
        private readonly INewsCommentRepo _newsCommentRepo;
        private readonly INewsImageRepo _newsImageRepo;
        private readonly IHubContext<SignalService> _hubContex;
        private readonly UserManager<User> _userManager;

        public NewsController(INewsRepo NewsRepo, IUtitlities utitlities, INewsCommentRepo newsCommentRepo,
            INewsImageRepo newsImage,
            IHubContext<SignalService> hubContex,
            UserManager<User> userManager)
        {
            _newsRepo = NewsRepo;
            _utitlities = utitlities;
            _newsCommentRepo = newsCommentRepo;
            _newsImageRepo = newsImage;
            _hubContex = hubContex;
            _userManager = userManager;
        }

        [HttpGet("getNews")]
        public async Task<IActionResult> GetNews(int pageNo = 1)
        {
            try
            {
                var Data = await _newsRepo.GetAllNews_4admin(pageNo);
                var Count = _newsRepo.GetNewsCount_All();
                return Ok(new
                {
                    data = Data,
                    count = Count
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getNewsByStatus/{status}")]
        public async Task<IActionResult> GetBlogsByStatus(bool status,int pageNo = 1)
        {
            var Data = await _newsRepo.GetNewsByStatus(status, pageNo);
            var Count = _newsRepo.GetNewsCount_ByStatus(status);
            return Ok(new
            {
                data = Data,
                count = Count
            });
        }

        [HttpGet("getNewsById/{id}")]
        public async Task<IActionResult> GetNewsById(int id)
        {
            var Data = await _newsRepo.GeNewsById_4Admin(id);
            var Images = await _newsRepo.Get_NewsImages(id);
            if (Data == null)
                return NotFound();

            return Ok(new
            {
                data = Data,
                images = Images
            });
        }        

        [HttpGet("getNewsBy/{id}")]
        public async Task<IActionResult> GetNewsBy(int id)
        {
            try
            {
                var News = await _newsRepo.Get_NewsById(id);
                var Images = await _newsRepo.Get_NewsImages(id);
                if (News == null)
                    return NotFound();

                return Ok(new
                {
                    news = News,
                    images = Images
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }       
        }

        [HttpGet("getComments/{id}")]
        public async Task<IActionResult> GetCommentsByNews(int id, int pageNo = 1)
        {
            try
            {
                var result = await _newsCommentRepo.GetComments(id, pageNo);
                var Count = _newsCommentRepo.GetCommentsCountByNewsId(id);
                return Ok(new
                {
                    data = result,
                    count = Count
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }

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
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("filterNews")]
        public async Task<IActionResult> FilterNews(FiltersDTO filter)
        {
            try
            {
                var Data = await _newsRepo.FilterNews(filter);
                return Ok(new
                {
                    data = Data,
                    count = Data.Count()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("getNewsTypes")]
        public async Task<IActionResult> GetNewsTypes()
        {
            var Data = await _newsRepo.GetNewsTypes();            
            return Ok(Data);
        }

        [HttpPost("addNews")]
        public async Task<IActionResult> AddNews(NewsOperDTO news)
        {
            try
            {
                bool finalResult = false;

                var userId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
                news.UserId = Convert.ToInt32(userId);
                news.CreatedDateM = DateTime.UtcNow.AddHours(3);
                news.CreatedDateH = Convert.ToDateTime(_utitlities.ToHijri(news.CreatedDateM));
                news.IsAccepted = true;

                var newNews = await _newsRepo.AddNews(news);
                if (newNews.Id > 0)
                {
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

        [HttpGet("setAcceptStatus/{status}/{id}")]
        public async Task<IActionResult> SetAcceptStatus(bool status, int id)
        {
            try
            {
                var result = await _newsRepo.SetAcceptStatus(status, id);
                if (result)
                {
                    var newsAdded = await _newsRepo.GetNewsById(id);
                    if (status == true)
                    {
                        await _hubContex.Clients.All.SendAsync("getData", newsAdded);
                    }

                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("setNotAcceptStatus/{status}/{id}")]
        public async Task<IActionResult> SetAcceptStatus(bool status, int id, int userId, string body)
        {
            try
            {
                var result = await _newsRepo.SetAcceptStatus(status, id);
                if (result)
                {
                    var newsAdded = await _newsRepo.GetNewsById(id);
                    if (status == true)
                    {
                        await _hubContex.Clients.All.SendAsync("getData", newsAdded);
                        return Ok();
                    }
                    else
                    {
                        var _user = await _userManager.FindByIdAsync(userId.ToString());

                        List<string> mails = new List<string>();
                        var isSendMail = false;
                        var subject = "ادارة تطبيق الاسرة";

                        var title = "<b>السلام عليكم , </b><br />اخي العزيز: <br /><br />";
                        var footer = "<br /></br />" + "ادارة التطبيق" + "<br /></br />";
                        var mailBody = "";

                        if (body == "" || body == null)
                        {
                            body = "نعتذر عن نشر طلبك لتعارضه مع الشروط والاحكام الخاصه بالتطبيق. <br /><br />" + footer;
                            mailBody = title + body;
                        }
                        else
                        {
                            mailBody = title + body + footer;
                        }

                        mails.Add(_user.Email);
                        isSendMail = _utitlities.SendMail(mails, mailBody, subject);
                        if (result && isSendMail)
                        {
                            return Ok();
                        }
                        else
                        {
                            await _newsRepo.SetNewsWatting(id);
                            return BadRequest();
                        }
                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("addNewsComment")]
        public async Task<IActionResult> AddComment(AddNewsCommentDTO comment)
        {
            try
            {
                comment.CreatedDateM = DateTime.UtcNow.AddHours(3);
                //comment.CreatedDateM = DateTime.Now;
                comment.CreatedDateH = Convert.ToDateTime(_utitlities.ToHijri(comment.CreatedDateM));
                var userId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
                comment.UserId = Convert.ToInt32(userId);
                comment.IsAccepted = true;

                var result = await _newsCommentRepo.AddComment(comment);
                if (result)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpGet("deleteComment/{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            try
            {
                var result = await _newsCommentRepo.DeleteComment(id);
                if (result)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("updateNews")]
        public async Task<IActionResult> UpdateNews(NewsOperDTO news)
        {
            try
            {
                bool finalResult = false;
                var result = await _newsRepo.UpdateNews(news);
                if (result)
                {
                    var userId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
                    if (news.NewsImages.Count > 0)
                    {
                        foreach (var image in news.NewsImages)
                        {
                            if (image.NewsId == 0)
                            {
                                image.CreatedDateM = DateTime.UtcNow.AddHours(3);
                                image.CreatedDateH = Convert.ToDateTime(_utitlities.ToHijri(image.CreatedDateM));
                                image.NewsId = news.Id;
                                finalResult = await _newsImageRepo.AddNewsImage(image);
                            }
                            else
                            {
                                finalResult = true;
                            }
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
                    return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("deleteImage/{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            try
            {
                var result = await _newsRepo.DeleteImage(id);
                if (result)                
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

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

        [HttpGet("acceptUserComment/{id}")]
        public async Task<IActionResult> AcceptUserComment(int id, int commentId)
        {
            var result = await _newsCommentRepo.AcceptUserComment(id, commentId);
            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpGet("getNewsWatting")]
        public async Task<IActionResult> GetNewsWatting(int pageNo = 1)
        {
            var Data = await _newsRepo.GetNewsWatting(pageNo);
            var Count = _newsRepo.GetNewsCount_Watting();
            return Ok(new
            {
                data = Data,
                count = Count
            });
        }

        //Not accepted
        [HttpGet("getNewsRefusalComments/{id}")]
        public async Task<IActionResult> GetNewsRefusalComments(int id, int pageNo = 1)
        {
            var Data = await _newsRepo.GetNewsRefusalComments(id, pageNo);
            var Count = _newsRepo.GetNewsComments_Refuse_Count(id);
            return Ok(new
            {
                data = Data,
                count = Count
            });
        }

        [HttpGet("getCommentsWatting/{id}")]
        public async Task<IActionResult> GetCommentsWatting(int id, int pageNo = 1)
        {
            var Data = await _newsCommentRepo.GetNewsCommentsWatting(id, pageNo);
            var Count = _newsRepo.GetNewsCommentsCount_Watting(id);
            return Ok(new
            {
                data = Data,
                count = Count
            });
        }

        [HttpGet("refuseUserComment/{id}")]
        public async Task<IActionResult> RefuseUserComment(int id, int commentId)
        {
            var result = await _newsCommentRepo.RefuseUserComment(id, commentId);
            if (result)
                return Ok();

            return BadRequest();
        }
    }
}