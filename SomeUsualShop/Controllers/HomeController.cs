using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SomeUsualShop.Models.Interfaces;

namespace SomeUsualShop.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _products;

        public HomeController(IProductRepository products)
        {
            _products = products;
        }

        public IActionResult Index() => View();
        
        public IActionResult About() => View();
        public ViewResult Reviews()=> View();

        [Route("/Home/Catalog/")]
        public IActionResult Catalog() => View(_products.Products
            .OrderBy(p=>p.Category.Name)
            .ThenBy(p=>p.Name));
        [Route("/Home/Catalog/{id}")]
        public IActionResult Catalog(int id) => View(_products.Products.Where(p => p.CategoryId == id));
        [HttpGet]
        public IActionResult Search(string searchString) => 
            View("Catalog",_products.Products.Where(p => p.Name.Contains(searchString)));
    }
}