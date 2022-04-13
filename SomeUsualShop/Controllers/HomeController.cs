using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SomeUsualShop.Models;

namespace SomeUsualShop.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;
        
        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index() => View();
        
        public IActionResult About() => View();
        public ViewResult Reviews()=> View();

        [Route("/Home/Catalog/")]
        public IActionResult Catalog() => View(_repository.Products);
        [Route("/Home/Catalog/{id}")]
        public IActionResult Catalog(int id) => View(_repository.Products.Where(p => p.CategoryId == id));
        [HttpGet]
        public IActionResult Search(string searchString) => 
            View("Catalog",_repository.Products.Where(p => p.Name.Contains(searchString)));
    }
}