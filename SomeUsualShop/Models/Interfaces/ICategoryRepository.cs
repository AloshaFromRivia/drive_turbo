using System.Linq;

namespace SomeUsualShop.Models.Interfaces
{
    public interface ICategoryRepository
    {
        IQueryable<Category> Categories { get;}
        void AddCategory(Category category);
        void RemoveCategory(long id);
    }
}