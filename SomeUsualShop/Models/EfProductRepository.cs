using System.Linq;
using SomeUsualShop.Models.Interfaces;

namespace SomeUsualShop.Models
{
    public class EfProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;

        public EfProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Product> Products => _context.Products;
        public  void AddProduct(Product product)
        {
            var item = _context.Products.FirstOrDefault(p=>p.Id==product.Id);
            if (item != null)
            {
                item.Name = product.Name;
                item.Description = product.Description;
                item.Price = product.Price;
                item.CategoryId = product.CategoryId;
            }
            else
            {
                _context.Products.Add(product);
            }
              _context.SaveChanges();
        }

        public void RemoveProduct(long id)
        {
            var item = _context.Products.FirstOrDefault(p => p.Id == id);
            if (item != null)
            {
                _context.Products.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}