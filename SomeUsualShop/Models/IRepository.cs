using System.Collections;
using System.Collections.Generic;

namespace SomeUsualShop.Models
{
    public interface IRepository
    {
        IEnumerable<Product> Products { get;}
        IEnumerable<Category> Categories { get;}
        void Add(Product product);
        void Remove(long id);
    }
}