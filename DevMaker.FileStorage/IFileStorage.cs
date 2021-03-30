﻿using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;


namespace DevMaker.FileStorage
{
    public interface IFileStorage
    {
        Task<string> UploadFileAsync(IFormFile imageFile, string fileNameForStorage);
        Task DeleteFileAsync(string fileNameForStorage);
    }
}