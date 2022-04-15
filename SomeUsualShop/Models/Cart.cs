using System.Collections.Generic;
using System.Linq;

namespace SomeUsualShop.Models
{
    public class Cart
    {
        private List<CartItem> _cartItems = new List<CartItem>();

        public virtual IEnumerable<CartItem> Items => _cartItems;
        public virtual decimal SubTotal() => _cartItems.Sum(p => p.Product.Price*p.Count);

        public virtual void Clear() => _cartItems.Clear();

        public virtual void AddItem(Product product, int count)
        {
            CartItem cartItem = _cartItems
                .FirstOrDefault(c => c.Product.Id == product.Id);

            if (cartItem == null)
            {
                _cartItems.Add(new CartItem()
                {
                    Product = product,
                    Count = count
                });
            }
            else
            {
                cartItem.Count += count;
            }
        }

        public virtual void Remove(Product product)
        {
            _cartItems.RemoveAll(p => p.Product.Id == product.Id);
        }
        
    }
}