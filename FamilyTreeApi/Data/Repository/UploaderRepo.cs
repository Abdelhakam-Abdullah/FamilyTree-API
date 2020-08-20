using FamilyTreeApi.Data.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.Repository
{
    public class UploaderRepo : IUploaderRepo   
    {
        private IHostingEnvironment _hostingEnvironment;

        public UploaderRepo() {}

        public void DeleteFiles(string filename, string path, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;

            var filePath = _hostingEnvironment.WebRootPath + "\\Images\\" + path + "\\" + filename;
            if (File.Exists(filePath))
            {
                var fileInfo = new FileInfo(filePath);
                fileInfo.Delete();
            }
        }

        public void DeleteFileExpect(string filenameExpect, string path, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;

            var pathFiles = _hostingEnvironment.WebRootPath + "\\Images\\" + path;
            var _filenameExpect = _hostingEnvironment.WebRootPath + "\\Images\\" + path + "\\" + filenameExpect;


            string[] filePaths = Directory.GetFiles(pathFiles);
            foreach (string file in filePaths)
            {
                var name = new FileInfo(file).Name;
                if (name != filenameExpect)
                {
                    File.Delete(file);
                }
            }

        }

        public async Task<string> UploadFile([FromForm] IFormFile file, IHostingEnvironment hostingEnvironment, string imagesPath)
        {
            _hostingEnvironment = hostingEnvironment;
            try
            {
                string fileName = "";
                if (file.Length > 0)
                {
                    string webRootPath = _hostingEnvironment.WebRootPath + "\\Images\\" + imagesPath + "\\";
                    fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    string fullPath = Path.Combine(webRootPath, fileName);

                    using (FileStream fileStream = System.IO.File.Create(fullPath))
                    {
                        await file.CopyToAsync(fileStream);
                        await fileStream.FlushAsync();
                    }
                }
                return fileName;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

    }
}
