using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyTreeApi.Data.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTreeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UtitlitiesController : ControllerBase
    {
        private readonly IUtitlities _utitlities;
        public UtitlitiesController(IUtitlities utitlities)
        {
            _utitlities = utitlities;
        }

        [HttpGet("getCurrentDomain")]
        public IActionResult GetCurrentDomain()
        {
            var domain = _utitlities.GetCurrentDomainName();
            return Ok(domain);
        }
    }
}
