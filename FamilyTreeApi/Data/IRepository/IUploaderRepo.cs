using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.IRepository
{
    public interface IUploaderRepo
    {
        Task<string> UploadFile([FromForm] IFormFile file, IHostingEnvironment hostingEnvironment, string imagesPath);
        void DeleteFiles(string filename, string path, IHostingEnvironment hostingEnvironment);
        void DeleteFileExpect(string filenameExpect, string path, IHostingEnvironment hostingEnvironment);
    }
}
