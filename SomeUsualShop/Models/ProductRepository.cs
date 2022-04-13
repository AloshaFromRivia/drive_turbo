using System.Collections.Generic;
using System.Linq;

namespace SomeUsualShop.Models
{
    public class ProductRepository : IRepository
    {
        private List<Product> _products;
        private List<Category> _categories;

        public IEnumerable<Product> Products => _products;
        public IEnumerable<Category> Categories => _categories;

        public ProductRepository()
        {
            //Initialisation
            _categories = new List<Category>();
            _products = new List<Product>();
            
                
            _categories.AddRange(new []
            {
                new Category()
                {
                    Id = 0,
                    Name = "Масла"
                },
                new Category()
                {
                    Id = 1,
                    Name = "Аккамуляторы"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Запчасти для ТО"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Шины"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Диски"
                },
            });
            
            _products.AddRange(new []
            {
                new Product()
                {
                    Id = 0,
                    Name = "Ford",
                    Price = 7196,
                    Description = "Описание для масла",
                    CategoryId = 0,
                    ImagePath = "/img/products/oil1.png"
                },
                new Product()
                {
                    Id = 1,
                    Name = "Lukoil",
                    Price = 4597,
                    Description = "Описание для масла 2",
                    CategoryId = 0,
                    ImagePath = "/img/products/oil2.jpeg"
                },
                new Product()
                {
                    Id = 2,
                    Name = "Exide",
                    Price = 24016,
                    Description = "Описание для аккамулятора",
                    CategoryId = 1,
                    ImagePath = "/img/products/acc1.jpeg"
                }
            });
        }
        
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Remove(long id)
        {
            _products.Remove(_products.First(p => p.Id == id));
        }

    }
}