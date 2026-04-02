using EFCoreAssignment2.DataBase;
using EFCoreAssignment2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment2.Controllers
{
    public class CourseController:Controller
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Courses.ToList());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        public IActionResult Edit(int id)
        {
            return View(_context.Courses.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            _context.Update(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return View(_context.Courses.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = _context.Courses.Find(id);
            _context.Remove(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
