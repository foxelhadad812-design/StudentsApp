using Microsoft.AspNetCore.Mvc;
using StudentsApp.Models;

namespace StudentsApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly List<string> _departments = new List<string> { "CS", "IT", "AI", "IS" };

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = _departments;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (string.IsNullOrEmpty(student.Department) || !_departments.Contains(student.Department))
            {
                ModelState.AddModelError("Department", "Department must be one of the following: CS, IT, AI, IS");
            }

            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Departments = _departments;
            return View(student);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            ViewBag.Departments = _departments;
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(student.Department) || !_departments.Contains(student.Department))
            {
                ModelState.AddModelError("Department", "Department must be one of the following: CS, IT, AI, IS");
            }

            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Departments = _departments;
            return View(student);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
