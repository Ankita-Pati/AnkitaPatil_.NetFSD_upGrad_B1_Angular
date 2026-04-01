using EFCoreCodeFirstMVCAssignment1.Data;
using EFCoreCodeFirstMVCAssignment1.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreCodeFirstMVCAssignment1.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var accounts = _context.Accounts.ToList();
            return View(accounts);
        }

        // CREATE - GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE - POST
        [HttpPost]
        public IActionResult Create(Account account)
        {
            if (ModelState.IsValid)
            {
                account.CreateDate = DateTime.Now;
                _context.Accounts.Add(account);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        // EDIT - GET
        public IActionResult Edit(int id)
        {
            var account = _context.Accounts.Find(id);
            if (account == null) return NotFound();
            return View(account);
        }

        // EDIT - POST
        [HttpPost]
        public IActionResult Edit(Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Accounts.Update(account);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        // DELETE - GET
        public IActionResult Delete(int id)
        {
            var account = _context.Accounts.Find(id);
            if (account == null) return NotFound();
            return View(account);
        }

        // DELETE - POST
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var account = _context.Accounts.Find(id);
            _context.Accounts.Remove(account);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var account = _context.Accounts.Find(id);
            if (account == null) return NotFound();
            return View(account);
        }
    }
}
