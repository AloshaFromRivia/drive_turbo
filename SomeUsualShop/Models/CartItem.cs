namespace SomeUsualShop.Models
{
    public class CartItem
    {
        public long Id { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }

    }
}