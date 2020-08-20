using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTreeApi.Controllers.Admin
{
    [Route("api/admin/[controller]")]
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
        [HttpGet("getFamilyChars")]
        public async Task<IActionResult> GetFamilyCharacters(int pageNo = 1)
        {
            try
            {
                var Data = await _familyCharacters.GetFamilyCharacters_4Admin(pageNo);
                return Ok(new
                {
                    data = Data,
                    count = _familyCharacters.GeFCCount_All()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("filterFamilyChar/{id}")]
        public async Task<IActionResult> FilterFamilyCharacters(string id)
        {
            var Data = await _familyCharacters.FilterFamilyCharacters_4Admin(id.Trim());
            return Ok(new
            {
                data = Data,
                count = Data.Count()
            });
        }

        [HttpGet("deleteFamilyChar/{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            try
            {
                var result = await _familyCharacters.DeleteFamilyChar(id);
                if (result)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("setAcceptStatus/{status}/{id}")]
        public async Task<IActionResult> SetAcceptStatus(bool status, int id)
        {
            var result = await _familyCharacters.SetAcceptStatus(id, status);
            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpGet("getFamilyCharById/{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var result = await _familyCharacters.GetFamilyCharactersById_4Admin(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("updateFC")]
        public async Task<IActionResult> Update(FamilyCharUpdateDTO familyChar)
        {
            var result = await _familyCharacters.UpdateFamilyChar(familyChar);
            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddFamilyCharacter(FamilyCharAddDTO FamilyChar)
        {
            try
            {
                FamilyChar.CreatedDateM = DateTime.UtcNow.AddHours(3);
                //FamilyChar.CreatedDateM = DateTime.Now;
                FamilyChar.CreatedDateH = Convert.ToDateTime(_utitlities.ToHijri(FamilyChar.CreatedDateM));
                FamilyChar.IsAccepted = true;
                FamilyChar.UserId = Convert.ToInt32((User.Claims.FirstOrDefault(c => c.Type == "Id").Value));

                var result = await _familyCharacters.Add(FamilyChar);
                if (result)
                    return Ok();

                return BadRequest();
            }
            // show when insert duplicate family charecter
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpGet("getFamilyCharWattings")]
        public async Task<IActionResult> GetFamilyCharWattings(int pageNo = 1)
        {
            var Data = await _familyCharacters.GetFamilyCharWattings(pageNo);
            var Count = _familyCharacters.GetFamilyCharWattings_Count();
            return Ok(new
            {
                data = Data,
                count = Count
            });
        }

        [HttpGet("getFamilyCharByStatus/{status}/{id}")]
        public async Task<IActionResult> GetBlogsByStatus(bool status, int id = 1)
        {
            var Data = await _familyCharacters.GetFamilyCharByStatus(status, id);
            var Count = _familyCharacters.GetFamilyByStatus_Count(status);
            return Ok(new
            {
                data = Data,
                count = Count
            });
        }

        [HttpGet("updateFamilyCharStatus/{status}/{id}")]
        public async Task<IActionResult> UpdateFamilyCharStatus(bool status, int id)
        {
            var result = await _familyCharacters.UpdateFamilyCharStatus(id, status);
            var FamilyCharacters = await _familyCharacters.GetFamilyCharacters_4Admin(1);
            var FamilyCharactersWatting = await _familyCharacters.GetFamilyCharWattings(1);

            if (result)
                return Ok();                

            return BadRequest();
        }
    }
}