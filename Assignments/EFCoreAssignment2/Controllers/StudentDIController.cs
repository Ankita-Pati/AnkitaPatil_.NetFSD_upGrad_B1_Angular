using EFCoreAssignment2.Models;
using EFCoreAssignment2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment2.Controllers
{
    public class StudentDIController : Controller
    {
        private readonly IStudentRepository _repo;

        public StudentDIController(IStudentRepository repo)
        {
            _repo = repo;
        }

        // READ
        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }

        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // EDIT
        public IActionResult Edit(int id)
        {
            return View(_repo.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            _repo.Update(student);
            return RedirectToAction("Index");
        }

        // DELETE
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
