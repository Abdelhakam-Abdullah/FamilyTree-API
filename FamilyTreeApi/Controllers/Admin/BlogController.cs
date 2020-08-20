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
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepo _blogRepo;
        private readonly IUtitlities _utitlities;
        private readonly IBlogCommentRepo _blogCommentRepo;
        private readonly UserManager<User> _userManager;
        

        public BlogController(IBlogRepo blogRepo, IUtitlities utitlities, IBlogCommentRepo blogCommentRepo,
            UserManager<User> userManager)
        {
            _blogRepo = blogRepo;
            _utitlities = utitlities;
            _blogCommentRepo = blogCommentRepo;
            _userManager = userManager;
            
        }
     
        //get all blogs
        [HttpGet("getBlogs")]
        public async Task<IActionResult> GetBlogs(int pageNo = 1)
        {
            var Data = await _blogRepo.GetAllBlogs_4admin(pageNo);
            var Count = _blogRepo.GetBlogsCount_All();
            return Ok(new
            {
                data = Data,
                count = Count
            });
        }

        //get blog by id
        [HttpGet("getBlogById/{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var result = await _blogRepo.GetBlogById_4Admin(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        //Insert new blog
        [HttpPost("addBlog")]
        public async Task<IActionResult> AddBlog(AddBlogDTO blog)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
                blog.UserId = Convert.ToInt32(userId);
                blog.CreatedDateM = DateTime.UtcNow.AddHours(3);
                blog.CreatedDateH = Convert.ToDateTime(_utitlities.ToHijri(blog.CreatedDateM));
                blog.IsAccepted = true;

                var result = await _blogRepo.AddBlog(blog);
                if (result)                
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        //get all blogs 5
        [HttpGet("getBlogsCount")]
        public int GetBlogsCount()
        {
            return  _blogRepo.GetBlogsCount_All();
        }

        [HttpPost("updateBlog")]
        public async Task<IActionResult> UpdateBlog(AddBlogDTO blog)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
                blog.UserId = Convert.ToInt32(userId);

                var result = await _blogRepo.UpdateBlog(blog);
                if (result)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("deleteBlog/{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            try
            {
                var result = await _blogRepo.DeleteBlog(id);
                if (result)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("deleteComment/{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            try
            {
                var result = await _blogCommentRepo.DeleteComment(id);
                if (result)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("getBlogsByStatus")]
        public async Task<IActionResult> GetBlogsByStatus(string status, int pageNo = 1)
        {
            try
            {
                var Data = await _blogRepo.GetBlogsByStatus(status, pageNo);
                var Count = _blogRepo.GetBlogsCount_byStatus(status);
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
        
        [HttpPost("filterBlogs")]
        public async Task<IActionResult> FilterBlogs(FiltersDTO filter)
        {
            try
            {
                var Data = await _blogRepo.FilterBlogs(filter);
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

        [HttpGet("setAcceptStatus/{status}/{id}")]
        public async Task<IActionResult> SetAcceptStatus(bool status,int id)
        {
            var result = await _blogRepo.SetAcceptStatus(status, id);
            if (result)
                return Ok();

            return BadRequest();
        }

        [AllowAnonymous]
        [HttpGet("setNotAcceptStatus")]
        public async Task<IActionResult> SetNotAcceptStatus(int blogId, int userId, string body)
        {
            var result = await _blogRepo.SetAcceptStatus(false, blogId);
            if (result)
            {
                var _user = await _userManager.FindByIdAsync(userId.ToString());

                List<string> mails = new List<string>();
                var isSendMail = false;
                var subject = "ادارة تطبيق الاسرة";

                var title = "<b>السلام عليكم , </b><br />اخي العزيز: <br /><br />";
                var footer =  "<br /></br />" + "ادارة التطبيق" + "<br /></br />" ;
                var mailBody = "";

                if (body == "" || body == null)
                {
                    body = "نعتذر عن نشر طلبك لتعارضه مع الشروط والاحكام الخاصه بالتطبيق. <br /><br />" +  footer;
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
                    await _blogRepo.SetBlogWatting(blogId);
                    return BadRequest();
                }                
            }
            return BadRequest();
        }

        [HttpPost("addBlogComment")]
        public async Task<IActionResult> AddComment(AddBlogCommentDTO comment)
        {
            try
            {
                comment.CreatedDateM = DateTime.UtcNow.AddHours(3);
                //comment.CreatedDateM = DateTime.Now;
                comment.CreatedDateH = Convert.ToDateTime(_utitlities.ToHijri(comment.CreatedDateM));
                var userId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
                comment.UserId = Convert.ToInt32(userId);
                comment.IsAccepted = true;

                var result = await _blogCommentRepo.AddComment(comment);
                if (result)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex); }
        }        

        [HttpGet("acceptUserBlogComment/{id}/{status}")]
        public async Task<IActionResult> AcceptUserBlogComment(int id, int commentId, bool status)
        {
            var result = await _blogRepo.AcceptUserBlogComment(id, commentId, status);
            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpGet("getComments/{id}")]
        public async Task<IActionResult> GetCommetsByBlodId(int id, int pageNo = 1)
        {
            var result = await _blogCommentRepo.GetAllCommentsByBlog(id, pageNo);
            var Count = _blogCommentRepo.GetCountBlogsComments_ByBlogId(id);
            return Ok(new
            {
                data = result,
                count = Count
            });
        }

        //Watting
        [HttpGet("getBlogCommentsWatting/{id}")]
        public async Task<IActionResult> GetCommentsNotAccepted(int id, int pageNo = 1)
        {
            var Data = await _blogRepo.GetBlogCommentsWatting(id, pageNo);
            var Count = _blogRepo.GetBlogComments_Watting_Count(id);
            return Ok(new
            {
                data = Data,
                count = Count
            });
        }

        //Not accepted
        [HttpGet("getBlogRefusalComments/{id}")]
        public async Task<IActionResult> GetBlogRefusalComments(int id, int pageNo = 1)
        {
            var Data = await _blogRepo.GetBlogRefusalComments(id, pageNo);
            var Count = _blogRepo.GetBlogComments_Refuse_Count(id);
            return Ok(new
            {
                data = Data,
                count = Count
            });
        }
    }
}