using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyTreeApi.Data.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTreeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploaderController : ControllerBase
    {
        private IHostingEnvironment _hostingEnvironment;
        private readonly IUploaderRepo _uploaderRepo;

        public UploaderController(IUploaderRepo uploaderRepo, IHostingEnvironment HostingEnvironment)
        {
            _uploaderRepo = uploaderRepo;
            _hostingEnvironment = HostingEnvironment;
        }

        [AllowAnonymous]
        [HttpPost("upload/{path}")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file, string path)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return BadRequest();

                var result = await _uploaderRepo.UploadFile(file, _hostingEnvironment, path);
                var imageName = result;
                return Ok(imageName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}