using EFCoreAssignment2.Models;
using EFCoreAssignment2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment2.Controllers
{
    public class CourseDIController : Controller
    {
        private readonly ICourseRepository _repo;

        public CourseDIController(ICourseRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        public IActionResult Edit(int id)
        {
            return View(_repo.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            _repo.Update(course);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return View(_repo.GetById(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
