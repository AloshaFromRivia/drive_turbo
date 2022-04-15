using System.Collections.Generic;
using System.Linq;

namespace SomeUsualShop.Models
{
    public class FakeRepository
    {
      
        private List<Product> _products;
        private List<Category> _categories;

        public IQueryable<Category> Categories => _categories.AsQueryable();
        public IQueryable<Product> Products => _products.AsQueryable();
        

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            _products.Remove(product);
        }

  
        public void AddCategory(Category category)
        {
            _categories.Add(category);
        }

        public void RemoveCategory(Category category)
        {
            _categories.Remove(category);
        }
    }
}