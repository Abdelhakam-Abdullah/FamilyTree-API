using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.DTOs;
using FamilyTreeApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FamilyTreeApi.Controllers.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepo _blogRepo;
        private readonly IUtitlities _utitlities;
        private readonly IHubContext<SignalService> _hubContex;

        public BlogController(IBlogRepo blogRepo, IUtitlities utitlities,
            IHubContext<SignalService> hubContex)
        {
            _blogRepo = blogRepo;
            _utitlities = utitlities;
            _hubContex = hubContex;
        }

        //get all blogs
        [AllowAnonymous]
        [HttpGet("getBlogs")]
        public async Task<IActionResult> GetBlogs(int pageNo = 1)
        {
            var result = await _blogRepo.GetAllBlogs(pageNo);
            return Ok(result);
        }

        //get user blogs by user id
        [AllowAnonymous]
        [HttpGet("getBlogsByUser")]
        public async Task<IActionResult> GetBlogsByUser(int id, int pageNo = 1)
        {
            var result = await _blogRepo.GetAllBlogsByUser(id, pageNo);
            return Ok(result);
        }

        //get blog by id
        [AllowAnonymous]
        [HttpGet("getMyBlogById/{id}")]
        public async Task<IActionResult> GetMyBlogById(int id)
        {
            var result = await _blogRepo.GetMyBlogById(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        //get blog by id
        [AllowAnonymous]
        [HttpGet("getBlogById/{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var result = await _blogRepo.GetBlogById(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        //Insert new blog
        [AllowAnonymous]
        [HttpPost("addBlog")]
        public async Task<IActionResult> AddBlog(AddBlogDTO blog)
        {
            try
            {
                blog.CreatedDateM = DateTime.UtcNow.AddHours(3);
                blog.CreatedDateH = Convert.ToDateTime(_utitlities.ToHijri(blog.CreatedDateM));
                blog.IsAccepted = null;

                var result = await _blogRepo.AddBlog(blog);
                if (result)
                {
                    await _hubContex.Clients.All.SendAsync("getData", blog);
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
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

    }
}