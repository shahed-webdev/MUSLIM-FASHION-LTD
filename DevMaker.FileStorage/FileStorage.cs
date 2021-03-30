using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DevMaker.FileStorage
{
    public class FileStorage : IFileStorage
    {
        public async Task<string> UploadFileAsync(IFormFile imageFile, string fileNameForStorage)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteFileAsync(string fileNameForStorage)
        {
            throw new System.NotImplementedException();
        }
    }
}