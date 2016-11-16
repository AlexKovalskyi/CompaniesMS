using Microsoft.AspNetCore.Mvc;

namespace CompaniesMSWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        { 
            ViewData["Message"] = "Web application requirements/description.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Performer:";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
