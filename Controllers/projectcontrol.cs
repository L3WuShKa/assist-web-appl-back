using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using YourBackendProject.Models;

namespace YourBackendProject.Controllers
{
    public class ProjectController : Controller
    {
        private readonly YourDbContext _context;

        // Constructor pentru injectarea dependențelor
        public ProjectController(YourDbContext context)
        {
            _context = context;
        }

        // Acțiunea pentru afișarea tuturor proiectelor
        public IActionResult Index()
        {
            var projects = _context.Projects.ToList();
            return View(projects);
        }

        // Acțiunea pentru afișarea detaliilor unui proiect
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = _context.Projects.FirstOrDefault(p => p.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // Acțiunea pentru crearea unui nou proiect
        [HttpPost]
        public IActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                project.CreatedAt = DateTime.UtcNow;
                _context.Projects.Add(project);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // Acțiunea pentru editarea unui proiect existent
        [HttpPost]
        public IActionResult Edit(int id, Project project)
        {
            if (id != project.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    _context.SaveChanges();
                }
                catch
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // Acțiunea pentru ștergerea unui proiect
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var project = _context.Projects.FirstOrDefault(p => p.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
