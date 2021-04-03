using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace DevMaker.FileStorage
{

    public static class FileBuilder
    {
        static FileBuilder()
        {
            RootUrl = "/product";
            RootPath= Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "product");
        }

        public static string FileName(string title, string fileName)
        {
            var fileExtension = Path.GetExtension(fileName);
            var fileNameForStorage = $"{title}-{DateTime.Now:yyyyMMddHHmmss}{fileExtension}";

            return fileNameForStorage;
        }

        public static string RootUrl { get; }
        public static string RootPath { get; }
    }
}