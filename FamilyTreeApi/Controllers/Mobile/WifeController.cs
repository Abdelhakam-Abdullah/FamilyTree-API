using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTreeApi.Controllers.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class WifeController : ControllerBase
    {
        private readonly IWifeRepo _wifeRepo;
        public WifeController(IWifeRepo wifeRepo)
        {
            _wifeRepo = wifeRepo;
        }

        [AllowAnonymous]
        [HttpGet("getWifes/{id}")]
        public async Task<IActionResult> GetWifes(int id)
        {
            var result = await _wifeRepo.GetWifesByUser(id);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("addWife")]
        public async Task<IActionResult> AddNews(Wife wife)
        {
            try
            { 
                var result = await _wifeRepo.AddWife(wife);
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
        [HttpPost("updateWife")]
        public async Task<IActionResult> UpdateWife(Wife wife)
        {
            try
            {
                var result = await _wifeRepo.UpdateWife(wife);
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
        [HttpGet("deleteWife/{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            try
            {
                var result = await _wifeRepo.DeleteWife(id);
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