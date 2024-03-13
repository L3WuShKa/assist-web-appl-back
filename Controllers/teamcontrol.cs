using System.Linq;
using Microsoft.AspNetCore.Mvc;
using YourBackendProject.Models;

namespace YourBackendProject.Controllers
{
    public class TeamController : Controller
    {
        private readonly YourDbContext _context;

        // Constructor pentru injectarea dependențelor
        public TeamController(YourDbContext context)
        {
            _context = context;
        }

        // Acțiunea pentru afișarea tuturor echipelor
        public IActionResult Index()
        {
            var teams = _context.Teams.ToList();
            return View(teams);
        }

        // Acțiunea pentru afișarea detaliilor unei echipe
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = _context.Teams.FirstOrDefault(t => t.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // Acțiunea pentru crearea unei noi echipe
        [HttpPost]
        public IActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Teams.Add(team);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // Acțiunea pentru editarea unei echipe existente
        [HttpPost]
        public IActionResult Edit(int id, Team team)
        {
            if (id != team.TeamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(team);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // Acțiunea pentru ștergerea unei echipe
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var team = _context.Teams.FirstOrDefault(t => t.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(team);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
