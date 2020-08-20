using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FamilyTreeApi.Data.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTreeApi.Controllers.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeRepo _homeRepo;
        public HomeController(IHomeRepo homeRepo)
        {
            _homeRepo = homeRepo;
        }

        [AllowAnonymous]
        [HttpGet("getImages")]
        public async Task<IActionResult> GetImages(int pageNo = 1)
        {
            var UserImages = await _homeRepo.GetUserImages(pageNo);
            var NewsImages = await _homeRepo.GetNewsImages(pageNo);

            return Ok(new
            {
                userImages = UserImages,
                newsImages = NewsImages
            });
        }

    }
}