using System.ComponentModel.DataAnnotations;

namespace SomeUsualShop.Models
{
    public class Category
    {
        [Required]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}