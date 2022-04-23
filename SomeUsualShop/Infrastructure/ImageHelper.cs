using System;
using System.IO;
using System.Linq;
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

        public static string GetPathByByteArray(byte[] img)
        {
            if (img !=null)
            {
                return "data:image;base64,"+Convert.ToBase64String(img);
            }

            return "/img/noimage.png";
        }
    }
}