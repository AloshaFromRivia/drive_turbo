using System.Linq;
using SomeUsualShop.Models.Interfaces;

namespace SomeUsualShop.Models
{
    public class EfCategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext _context;

        public EfCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Category> Categories => _context.Categories;
        public void AddCategory(Category category)
        {
            var item = _context.Categories.FirstOrDefault(c=>c.Id==category.Id);
            if (item != null)
            {
                item.Name = category.Name;
            }
            else
            {
                _context.Categories.Add(category);
            }
            _context.SaveChanges();
        }

        public void RemoveCategory(long id)
        {
            var item = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                _context.Categories.Remove(item);
            }

            _context.SaveChanges();
        }
    }
}