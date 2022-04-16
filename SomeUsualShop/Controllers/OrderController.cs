using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SomeUsualShop.Models;
using SomeUsualShop.Models.Interfaces;

namespace SomeUsualShop.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository _orderRepository;
        private Cart _cart;

        public OrderController(IOrderRepository repository, Cart cart)
        {
            _orderRepository = repository;
            _cart = cart;
        }
        public IActionResult Index()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Index(Order order)
        {
            if (!_cart.Items.Any()) {
                ModelState.AddModelError("", "Ваша корзина пуста!");
            }
            if (ModelState.IsValid) {
                order.Items = _cart.Items.ToArray();
                _orderRepository.AddOrder(order);
                return RedirectToAction(nameof(Completed));
            } else {
                return View(order);
            }
        }
        
        public ViewResult Completed() {
            _cart.Clear();
            return View();
        }
    }
}