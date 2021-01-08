namespace WheelsMarket.Services
{
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public class CloudinaryService
    {
        public static async Task<string> UploadAsync(Cloudinary cloudinary, IFormFile file, string folderName, string userId)
        {
            
            string fileName = Guid.NewGuid().ToString();
            byte[] currentImage;

            using (var image = new MemoryStream())
            {
                await file.CopyToAsync(image); 
                currentImage = image.ToArray();
            }

            using var destinationStream = new MemoryStream(currentImage);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, destinationStream),
                PublicId = $"{folderName}/{fileName}"
            };
            var results = await cloudinary.UploadAsync(uploadParams);
            return results.Url.AbsoluteUri;
        }

    }
}
