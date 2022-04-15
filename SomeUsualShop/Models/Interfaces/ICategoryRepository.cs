using System.Collections.Generic;

namespace SomeUsualShop.Models.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get;}
        void AddCategory(Category category);
        void RemoveCategory(Category category);
    }
}