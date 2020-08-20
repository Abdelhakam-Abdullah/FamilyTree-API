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
    public class NewsCommentController : ControllerBase
    {
        private readonly INewsCommentRepo _newsCommentRepo;
        private readonly IUtitlities _utitlities;
        public NewsCommentController(INewsCommentRepo NewsCommentRepo, IUtitlities utitlities)
        {
            _newsCommentRepo = NewsCommentRepo;
            _utitlities = utitlities;
        }
        
        [AllowAnonymous]
        [HttpGet("GetCommentsByNews/{id}")]
        public async Task<IActionResult> GetCommentsByNews(int id, int pageNo = 1)
        {
            try
            {
                var Result = await _newsCommentRepo.GetComments(id, pageNo);
                //var Count = _newsCommentRepo.GetAllComments_ByNews(id);
                return Ok(Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [AllowAnonymous]
        [HttpPost("AddComment")]
        public async Task<IActionResult> AddNews(AddNewsCommentDTO comment)
        {
            try
            {
                comment.CreatedDateM = DateTime.UtcNow.AddHours(3);
                comment.CreatedDateH = Convert.ToDateTime(_utitlities.ToHijri(comment.CreatedDateM));
                comment.IsAccepted = null;

                var result = await _newsCommentRepo.AddNewsComment(comment);
                if (result)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

    }
}