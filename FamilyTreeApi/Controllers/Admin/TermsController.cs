using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTreeApi.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermsController : ControllerBase
    {
        private readonly ITermsRepo _termsRepo;
        public TermsController(ITermsRepo termsRepo)
        {
            _termsRepo = termsRepo;
        }

        [AllowAnonymous]
        [HttpGet("get")]
        public async Task<IActionResult> GetTerms()
        {
            try
            {
                var result = await _termsRepo.Get();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex); 
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTerms(Terms terms)
        {
            try
            {
                var result = await _termsRepo.Add(terms);
                if (result)
                    return Ok();

                return BadRequest();
            }
            catch (Exception) { return BadRequest(); }
        }

        //Update Definition and Lineage
        [HttpPost("update")]
        public async Task<IActionResult> UpdateTerms(Terms terms)
        {
            try
            {
                var result = await _termsRepo.Update(terms);
                if (result)
                    return Ok();

                return BadRequest();
            }
            catch (Exception) { return BadRequest(); }
        }
    }
}