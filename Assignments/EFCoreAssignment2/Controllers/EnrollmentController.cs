using EFCoreAssignment2.DataBase;
using EFCoreAssignment2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment2.Controllers
{
    public class EnrollmentController:Controller
    {
        private readonly AppDbContext _context;

        public EnrollmentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .ToList();

            return View(data);
        }

        public IActionResult Create()
        {
            ViewBag.Students = new SelectList(_context.Students, "Id", "Name");
            ViewBag.Courses = new SelectList(_context.Courses, "Id", "Title");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrollment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enrollment);
        }

        // GET: Edit
        public IActionResult Edit(int id)
        {
            var enrollment = _context.Enrollments.Find(id);

            ViewBag.Students = new SelectList(_context.Students, "Id", "Name", enrollment.StudentId);
            ViewBag.Courses = new SelectList(_context.Courses, "Id", "Title", enrollment.CourseId);

            return View(enrollment);
        }

        // POST: Edit
        [HttpPost]
        public IActionResult Edit(Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Update(enrollment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enrollment);
        }
        public IActionResult Delete(int id)
        {
            var data = _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .FirstOrDefault(e => e.Id == id);

            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = _context.Enrollments.Find(id);
            _context.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
