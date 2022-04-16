using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SomeUsualShop.Models
{
    public class Category
    {
        [Required]
        public long Id { get; set; }
        [DisplayName("Название категории")]
        public string Name { get; set; }
    }
}