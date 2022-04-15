using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SomeUsualShop.Models;
using SomeUsualShop.Models.Interfaces;
using SomeUsualShop.Models.ViewModels;

namespace SomeUsualShop.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository _products;
        private Cart _cart;

        public CartController(IProductRepository products, Cart cart)
        {
            _cart = cart;
            _products = products;
        }
        
        // GET
        public ViewResult Index(string returnUrl)
        {
            return View(new CartViewIndexModel()
            {
                Cart = _cart,
                ReturnUrl = returnUrl
            });
        }

        public IActionResult AddToCart(long id,string returnUrl)
        {
            var product = _products.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _cart.AddItem(product,1);
            }
            return RedirectToAction("Index", new{ returnUrl});
        }
        
        public IActionResult RemoveFromCart(long id,string returnUrl)
        {
            var product = _products.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _cart.Remove(product);
            }
            return RedirectToAction("Index", new{ returnUrl});
        }
    }
}