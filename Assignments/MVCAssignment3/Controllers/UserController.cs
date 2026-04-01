using Microsoft.AspNetCore.Mvc;
using MVCAssignment3.Models;
using MVCAssignment3.ViewModels;

namespace MVCAssignment3.Controllers
{
    public class UserController : Controller
    {
        // Temporary in-memory storage
        private static List<User> users = new List<User>();

        // ---------------- REGISTER ----------------

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                users.Add(user);
                return RedirectToAction("Login");
            }
            return View(user);
        }

        // ---------------- LOGIN ----------------

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("UserEmail", user.Email);
                return RedirectToAction("Profile");
            }

            ViewBag.Error = "Invalid credentials";
            return View();
        }

        // ---------------- PROFILE ----------------

        public IActionResult Profile()
        {
            var email = HttpContext.Session.GetString("UserEmail");

            if (email == null)
                return RedirectToAction("Login");

            var user = users.FirstOrDefault(u => u.Email == email);

            var model = new UserViewModel
            {
                Name = user.Name,
                Email = user.Email
            };

            return View(model);
        }

        // ---------------- EDIT ----------------

        public IActionResult Edit()
        {
            var email = HttpContext.Session.GetString("UserEmail");

            if (email == null)
                return RedirectToAction("Login");

            var user = users.FirstOrDefault(u => u.Email == email);

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User updatedUser)
        {
            var email = HttpContext.Session.GetString("UserEmail");

            if (email == null)
                return RedirectToAction("Login");

            var user = users.FirstOrDefault(u => u.Email == email);

            if (user != null)
            {
                user.Name = updatedUser.Name;
                user.Email = updatedUser.Email;

                HttpContext.Session.SetString("UserEmail", user.Email);
            }

            return RedirectToAction("Profile");
        }

        // ---------------- LOGOUT ----------------

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
