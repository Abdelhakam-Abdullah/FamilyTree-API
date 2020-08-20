using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTreeApi.Controllers.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCommentController : ControllerBase
    {
        private readonly IBlogCommentRepo _blogCommentRepo;
        private readonly IUtitlities _utitlities;

        public BlogCommentController(IBlogCommentRepo blogCommentRepo, IUtitlities utitlities)
        {
            _blogCommentRepo = blogCommentRepo;
            _utitlities = utitlities;
        }

        //get blog comments by blog id
        [AllowAnonymous]
        [HttpGet("getCommetsByBlogId")]
        public async Task<IActionResult> GetCommetsByBlodId(int id, int pageNo = 1)
        {
            var result = await _blogCommentRepo.GetAllCommentsByBlog(id);
            return Ok(result);
        }

        //Insert new blog
        [AllowAnonymous]
        [HttpPost("addComment")]
        public async Task<IActionResult> AddComment(AddBlogCommentDTO comment)
        {
            try
            {
                comment.CreatedDateM = DateTime.UtcNow.AddHours(3);
                comment.CreatedDateH = Convert.ToDateTime(_utitlities.ToHijri(comment.CreatedDateM));
                comment.IsAccepted = null;

                var result = await _blogCommentRepo.AddComment(comment);
                if (result)
                    return Ok();
            
                return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

    }
}