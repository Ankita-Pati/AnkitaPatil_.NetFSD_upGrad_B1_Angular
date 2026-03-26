using Microsoft.AspNetCore.Mvc;
using MVCAssignment1.Models;

namespace MVCAssignment1.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return Content("Student Index Page");
        }

        public IActionResult Profile()
        {
            return Content("Student Profile Page");
        }

        //public IActionResult Details()
        //{
        //    ViewBag.Name = "John";
        //    ViewBag.Age = 25;
        //    ViewData["Name"] = "John";
        //    ViewData["Age"] = 25;
        //    return View();
        //}
        //public IActionResult Details()
        //{
        //    var student = new Student
        //    {
        //        Name = "John",
        //        Age = 22
        //    };
        //    return View(student);
        //}

        public IActionResult Details(string name, int age)
        {
            ViewData["Message"] = "Student Info Page";

            var student = new Student
            {
                Name = name,
                Age = age
            };

            return View(student);
        }
        public IActionResult List()
        {
            var students = new List<string> { "John", "Emma", "Alex" };
            return View(students);
        }
    }
}
