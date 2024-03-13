using System.Linq;
using Microsoft.AspNetCore.Mvc;
using YourBackendProject.Models;

namespace YourBackendProject.Controllers
{
    public class SkillController : Controller
    {
        private readonly YourDbContext _context;

        // Constructor pentru injectarea dependențelor
        public SkillController(YourDbContext context)
        {
            _context = context;
        }

        // Acțiunea pentru afișarea tuturor abilităților
        public IActionResult Index()
        {
            var skills = _context.Skills.ToList();
            return View(skills);
        }

        // Acțiunea pentru afișarea detaliilor unei abilități
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = _context.Skills.FirstOrDefault(s => s.SkillId == id);
            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }

        // Acțiunea pentru crearea unei noi abilități
        [HttpPost]
        public IActionResult Create(Skill skill)
        {
            if (ModelState.IsValid)
            {
                _context.Skills.Add(skill);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(skill);
        }

        // Acțiunea pentru editarea unei abilități existente
        [HttpPost]
        public IActionResult Edit(int id, Skill skill)
        {
            if (id != skill.SkillId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(skill);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(skill);
        }

        // Acțiunea pentru ștergerea unei abilități
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var skill = _context.Skills.FirstOrDefault(s => s.SkillId == id);
            if (skill == null)
            {
                return NotFound();
            }

            _context.Skills.Remove(skill);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
