using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace DevMaker.FileStorage
{
    public static class FileStorage
    {
        //upload file
        public static async Task<string> UploadFileAsync(IFormFile imageFile, string fileNameForStorage)
        {
            if (imageFile == null) return null;

            var fileName = FileBuilder.FileName(fileNameForStorage, imageFile.FileName);
            var filePath = Path.Combine(FileBuilder.RootPath, fileName);

            await using var fileStream = new FileStream(filePath, FileMode.Create);
            await imageFile.CopyToAsync(fileStream);

            return fileName;
        }

        //delete file
        public static void DeleteFile(string fileNameForStorage)
        {
            var filePath = Path.Combine(FileBuilder.RootPath, fileNameForStorage);
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}