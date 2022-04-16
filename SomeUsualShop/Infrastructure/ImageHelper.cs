using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace SomeUsualShop.Infrastructure
{
    public static class ImageHelper
    {
        public static byte[] GetBytesFromImage(IFormFile file)
        {
            byte[] fileBytes=null;
            if (file.Length > 0)
            {
                
                using (var fs1 = file.OpenReadStream())
                using (var ms1 = new MemoryStream())
                {
                    fs1.CopyTo(ms1);
                    fileBytes = ms1.ToArray();
                }
            }

            return fileBytes;
        }
    }
}