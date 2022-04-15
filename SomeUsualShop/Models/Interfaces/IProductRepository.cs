using System.Collections.Generic;

namespace SomeUsualShop.Models.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        void AddProduct(Product product);
        void RemoveProduct(Product product);
    }
}