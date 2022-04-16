using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;

namespace SomeUsualShop.Models.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        public Product Product { get; set; }
        [DisplayName("Изображение")]
        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; }
    }
}