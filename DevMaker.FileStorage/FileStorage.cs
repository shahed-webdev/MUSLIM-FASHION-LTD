using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace DevMaker.FileStorage
{
    public class FileStorage : IFileStorage
    {
        //upload file
        public async Task<string> UploadFileAsync(IFormFile imageFile, string fileNameForStorage)
        {
            if (imageFile == null) return null;

            var fileName = FileBuilder.FileName(fileNameForStorage, imageFile.FileName);
            var filePath = Path.Combine(FileBuilder.BasePath(), fileName);
           
            await using var fileStream = new FileStream(filePath, FileMode.Create);
            await imageFile.CopyToAsync(fileStream);

            return fileName;
        }

        //delete file
        public void DeleteFile(string fileNameForStorage)
        {
            var filePath = Path.Combine(FileBuilder.BasePath(), fileNameForStorage);
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}