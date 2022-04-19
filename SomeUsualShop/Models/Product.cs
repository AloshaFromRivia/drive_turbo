using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SomeUsualShop.Models
{
    public class Product
    {
        [Required]
        public long Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }
        [DisplayName("Id категории")]
        public Category Category { get; set; }
        [DisplayName("Id категории")]
        [ForeignKey("Category")]
        public long CategoryId { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        [DisplayName("Изображение")]
        [BindNever]
        public byte[] Image { get; set; }
    }
}