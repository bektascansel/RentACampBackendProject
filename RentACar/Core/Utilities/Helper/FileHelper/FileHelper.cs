using Core.Utilities.Helper.FileHelper.Constants;
using Core.Utilities.Helper.GuideHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helper.FileHelper
{
    public class FileHelper : IFileHelper
    {
        public string Add(IFormFile file)
        {
            
            string fileExtension = Path.GetExtension(file.FileName);

          
            string uniqueFileName = GuidHelper.Create() + fileExtension;

            
            var imagePath = FilePath.Full(uniqueFileName);

            string directoryPath = Path.GetDirectoryName(imagePath);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
           
            using FileStream fileStream = new(imagePath, FileMode.Create);

            
            file.CopyTo(fileStream);

            
            fileStream.Flush();
            return uniqueFileName;
        }

        public void Delete(string path)
        {
           
            if (Path.Exists(FilePath.Full(path)))
            {
                File.Delete(FilePath.Full(path));
            }
            else
            {
                throw new DirectoryNotFoundException("File is not exist");
            }
        }

        public void Update(IFormFile file, string imagePath)
        {
            
            var fullpath = FilePath.Full(imagePath);
            if (Path.Exists(fullpath))
            {
                using FileStream fileStream = new(fullpath, FileMode.Create);
              
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            else
            {
                throw new DirectoryNotFoundException("File is not exist");
            }
        }
    }
}
