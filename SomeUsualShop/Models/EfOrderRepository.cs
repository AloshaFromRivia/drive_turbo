using System.Linq;
using Microsoft.EntityFrameworkCore;
using SomeUsualShop.Models.Interfaces;

namespace SomeUsualShop.Models
{
    public class EfOrderRepository : IOrderRepository
    {
        private ApplicationDbContext _context;

        public EfOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Order> Orders => _context.Orders
            .Include(o=>o.Items)
            .ThenInclude(i=>i.Product);
        
        public void AddOrder(Order order)
        {
            _context.AttachRange(order.Items.Select(l=>l.Product));
            if (order.Id == 0)
            {
                _context.Orders.Add(order);
            }

            _context.SaveChanges();
        }
    }
}