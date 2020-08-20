using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FamilyTreeApi.Data.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTreeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        private readonly IFamilyRepo _familyRepo;
        public FamilyController(IFamilyRepo familyRepo)
        {
            _familyRepo = familyRepo;
        }

        [AllowAnonymous]
        [HttpGet("getFamilies")]
        public async Task<IActionResult> GetFamilies()
        {
            var result = await _familyRepo.GetFamilies();
            return Ok(result);
        }
    }
}