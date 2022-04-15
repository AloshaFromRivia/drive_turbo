using System.Linq;

namespace SomeUsualShop.Models.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        void AddProduct(Product product);
        void RemoveProduct(long id);
    }
}