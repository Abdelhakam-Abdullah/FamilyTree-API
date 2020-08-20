using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTreeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefinitionLineageController : ControllerBase
    {
        private readonly IDefinitionLineageRepo _definition;
        public DefinitionLineageController(IDefinitionLineageRepo definition)
        {
            _definition = definition;
        }

        //[AllowAnonymous]
        [HttpGet("get")]
        public async Task<IActionResult> GetDefinitionLineage()
        {
            var result = await _definition.GetDefinitionLineage();
            return  Ok(result);
        }

        //Insert Definition and Lineage
        [AllowAnonymous]
        [HttpPost("add")]
        public async Task<IActionResult> AddFamilyCharacter(DefinitionLineage  definition)
        {
            try
            {
                var result = await _definition.Add(definition);
                if (result)
                    return Ok();

                return BadRequest();
            }
            catch (Exception) { return BadRequest(); }
        }

        //Update Definition and Lineage
        [HttpPost("update")]
        public async Task<IActionResult> UpdateFamilyCharacter(DefinitionLineage definition)
        {
            try
            {
                var result = await _definition.Update(definition);
                if (result)
                    return Ok();

                return BadRequest();
            }
            catch (Exception) { return BadRequest(); }
        }
    }
}