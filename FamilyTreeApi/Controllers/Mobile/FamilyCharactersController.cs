using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTreeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyCharactersController : ControllerBase
    {
        private readonly IFamilyCharactersRepo _familyCharacters;
        private readonly IUtitlities _utitlities;

        public FamilyCharactersController(IFamilyCharactersRepo familyCharacters, IUtitlities utitlities)
        {
            _familyCharacters = familyCharacters;
            _utitlities = utitlities;
        }

        [AllowAnonymous]
        [HttpGet("getFamilyCharacters")]
        public async Task<IActionResult> GetFamilyCharacters(int pageNo = 1)
        {
            var result = await _familyCharacters.GetFamilyCharacters(pageNo);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("GetFamilyCharacterDetails/{id}")]
        public async Task<IActionResult> GetFamilyCharacterDetails(int id)
        {
            try
            {
                var result = await _familyCharacters.GetFamilyCharacterDetails(id);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        //Filter family charecters by full name or like full name
        [AllowAnonymous]
        [HttpGet("filter")]
        public async Task<IActionResult> FilterFamilyCharacters(string search)
        {
            try
            {
                var result = await _familyCharacters.FilterFamilyCharacters(search);
                return Ok(result);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        //Filter family charecters by full name or like full name (for admin)
        [AllowAnonymous]
        [HttpGet("filterFC")]
        public async Task<IActionResult> FilterFamilyCharacter(string search)
        {
            try
            {
                var result = await _familyCharacters.FilterFamilyCharacters(search);
                return Ok(result);
            }
            catch (Exception) { return BadRequest(); }
        }

        //Insert new family charecter
        [AllowAnonymous]
        [HttpPost("add")]
        public async Task<IActionResult> AddFamilyCharacter(FamilyCharAddDTO FamilyChar)
        {
            try
            {
                FamilyChar.CreatedDateM = DateTime.UtcNow.AddHours(3);
                FamilyChar.CreatedDateH = Convert.ToDateTime(_utitlities.ToHijri(FamilyChar.CreatedDateM));
                FamilyChar.IsAccepted = null;

                var result = await _familyCharacters.Add(FamilyChar);
                if (result)
                    return Ok();

                return BadRequest();
            }
            // show when insert duplicate family charecter
            catch (Exception ex) { return BadRequest(ex); }
        }


    }
}