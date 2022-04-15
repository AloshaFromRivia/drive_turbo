using System.ComponentModel.DataAnnotations.Schema;

namespace SomeUsualShop.Models
{
    public class CartItem
    {
        public long Id { get; set; }
        [ForeignKey("Product")]
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }

    }
}