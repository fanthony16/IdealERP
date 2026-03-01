using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Utilities
{
    public class FileUploadProcessor
    {
        public string SaveToFolder(string folderPath, IFormFile _file, string fileName)
        {


            //var filePath = Path.Combine(folderPath, _file.FileName);
            var filePath = Path.Combine(folderPath, fileName);
            
            using (var stream = System.IO.File.Create(filePath))
            {
                _file.CopyTo(stream);
            }

           // Path.GetRelativePath(_env.WebRootPath, "/img/companylogo/defaultcompany.PNG").Replace("\\", "/");

            return filePath;
        }
    }
}
