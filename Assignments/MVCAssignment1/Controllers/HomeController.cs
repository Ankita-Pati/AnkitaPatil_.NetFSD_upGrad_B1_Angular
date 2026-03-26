using Microsoft.AspNetCore.Mvc;
using MVCAssignment1.Models;
using System.Diagnostics;

namespace MVCAssignment1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return Content("Welcome to ASP.NET Core MVC");
            ViewData["Title"] = "Home Page";
            ViewBag.Age = 20;
            return View();
        }

        public IActionResult About()
        {
            return Content("This is About Page");
        }

        public IActionResult Contact()
        {
            return Content("Contact us at support@test.com");
        }
    }
}
