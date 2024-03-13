using System.Linq;
using Microsoft.AspNetCore.Mvc;
using YourBackendProject.Models;

namespace YourBackendProject.Controllers
{
    public class RoleController : Controller
    {
        private readonly YourDbContext _context;

        // Constructor pentru injectarea dependențelor
        public RoleController(YourDbContext context)
        {
            _context = context;
        }

        // Acțiunea pentru afișarea tuturor rolurilor
        public IActionResult Index()
        {
            var roles = _context.CustomTeamRoles.ToList();
            return View(roles);
        }

        // Acțiunea pentru afișarea detaliilor unui rol
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = _context.CustomTeamRoles.FirstOrDefault(r => r.RoleId == id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // Acțiunea pentru crearea unui nou rol
        [HttpPost]
        public IActionResult Create(CustomTeamRole role)
        {
            if (ModelState.IsValid)
            {
                _context.CustomTeamRoles.Add(role);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }

        // Acțiunea pentru editarea unui rol existent
        [HttpPost]
        public IActionResult Edit(int id, CustomTeamRole role)
        {
            if (id != role.RoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(role);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }

        // Acțiunea pentru ștergerea unui rol
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var role = _context.CustomTeamRoles.FirstOrDefault(r => r.RoleId == id);
            if (role == null)
            {
                return NotFound();
            }

            _context.CustomTeamRoles.Remove(role);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
