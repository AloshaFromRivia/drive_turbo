using Microsoft.AspNetCore.Mvc;

namespace SomeUsualShop.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult About() => View();
        public ViewResult Reviews()=> View();
    }
}