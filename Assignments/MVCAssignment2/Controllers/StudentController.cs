using Microsoft.AspNetCore.Mvc;
using MVCAssignment2.Models;

namespace MVCAssignment2.Controllers
{
    public class StudentController : Controller
    {
        //public IActionResult Index()
        //{
        //    return Content("Welcome to Student Page");
        //}

        //public IActionResult Index()
        //{
        //    var student = new Student
        //    {
        //        Name = "Emma",
        //        Age = 22,
        //        Email = "emma@gmail.com"
        //    };

        //    return View(student);
        //}

        private static List<Student> students = new List<Student>();

        // READ
        public IActionResult Index()
        {
            return View(students);
        }

        // CREATE (GET)
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = students.Count + 1;
                students.Add(student);  
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // EDIT (GET)
        public IActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return View(student);
        }

        // EDIT (POST)
        [HttpPost]
        public IActionResult Edit(Student updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == updatedStudent.Id);

            if (student != null)
            {
                student.Name = updatedStudent.Name;
                student.Age = updatedStudent.Age;
                student.Email = updatedStudent.Email;
            }

            return RedirectToAction("Index");
        }

        // DELETE (GET)
        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return View(student);
        }

        // DELETE (POST)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student != null)
            {
                students.Remove(student);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Details()
        {
            return Content("Student Details Page");
        }

        public IActionResult GetStudent(int id)
        {
            return Content($"Student ID is {id}");
        }

        public IActionResult ShowData()
        {
            ViewBag.Name = "Emma";
            ViewData["Age"] = 22;

            return View();
        }

    }
}
