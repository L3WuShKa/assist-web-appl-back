using System.Linq;
using Microsoft.AspNetCore.Mvc;
using YourBackendProject.Models;

namespace YourBackendProject.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly YourDbContext _context;

        // Constructor pentru injectarea dependențelor
        public DepartmentController(YourDbContext context)
        {
            _context = context;
        }

        // Acțiunea pentru afișarea tuturor departamentelor
        public IActionResult Index()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }

        // Acțiunea pentru afișarea detaliilor unui departament
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = _context.Departments.FirstOrDefault(d => d.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // Acțiunea pentru crearea unui nou departament
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // Acțiunea pentru editarea unui departament existent
        [HttpPost]
        public IActionResult Edit(int id, Department department)
        {
            if (id != department.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(department);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // Acțiunea pentru ștergerea unui departament
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var department = _context.Departments.FirstOrDefault(d => d.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
