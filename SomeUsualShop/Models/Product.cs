using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SomeUsualShop.Models
{
    public class Product
    {
        [Required]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
       // public Category Category { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
    }
}