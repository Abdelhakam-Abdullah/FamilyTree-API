using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.DTOs;
using FamilyTreeApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTreeApi.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly IGeneralSettings _generalSettings;
        private readonly IUploaderRepo _uploaderRepo;
        private IHostingEnvironment _hostingEnvironment;

        public SettingsController(IGeneralSettings generalSettings, IUploaderRepo UploaderRepo, IHostingEnvironment HostingEnvironment)
        {
            _generalSettings = generalSettings;
            _uploaderRepo = UploaderRepo;
            _hostingEnvironment = HostingEnvironment;
        }

        [AllowAnonymous]
        [HttpGet("getSettings")]
        public IActionResult GetBlogs()
        {
            var result = _generalSettings.GetSettings();
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> addBlog(Settings settings)
        {
            try
            {
                var result = await _generalSettings.Add(settings);
                var _settings = _generalSettings.GetSettings();
                if (result)
                    return Ok(_settings);

                return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(Settings settings)
        {
            try
            {
                var result = await _generalSettings.Update(settings);
                if (result)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpPost("saveSettingImage/{logoName}")]
        public async Task<IActionResult> UploadUserImage(SettingsDTO settings,string logoName)
        {
            var _settings = await _generalSettings.GetSettingsById(settings.Id);           
            
            if (_settings != null)
            {

                string oldImage = "";
                if (logoName == "AppLogo")
                {
                    oldImage = _settings.AppLogo;
                    _settings.AppLogo = settings.AppLogo;
                }
                else if (logoName == "CPanelLogo")
                {
                    oldImage = _settings.CPanelLogo;
                    _settings.CPanelLogo = settings.CPanelLogo;
                }
                else
                {
                    oldImage = _settings.LoginLogo;
                    _settings.LoginLogo = settings.LoginLogo;
                }

                var result = await _generalSettings.UpdateLogo(settings, logoName);
                if (result)
                {
                    _uploaderRepo.DeleteFiles(oldImage, "Logos", _hostingEnvironment);
                    return Ok();
                }
                else
                    return BadRequest();
            }
             return NoContent();
        }
    }
}