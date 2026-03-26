using Microsoft.AspNetCore.Mvc;

namespace MVCAssignment1.Controllers
{
    public class MathController : Controller
    {
        public IActionResult Add(int a, int b)
        {
            return Content($"Addition: {a + b}");
        }

        public IActionResult Multiply(int a, int b)
        {
            return Content($"Multiplication: {a * b}");
        }
    }
}
