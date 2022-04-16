using System.Linq;

namespace SomeUsualShop.Models.Interfaces
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get;}
        void AddOrder(Order order);
    }
}