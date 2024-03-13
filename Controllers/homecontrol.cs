using Microsoft.AspNetCore.Mvc;

namespace YourBackendProject.Controllers
{
    public class HomeController : Controller
    {
        // Acțiunea pentru pagina principală
        public IActionResult Index()
        {
            // Afișează o pagină de bun venit pentru utilizator
            return View();
        }

        // Acțiunea pentru afișarea informațiilor despre echipă
        public IActionResult AboutTeam()
        {
            // Afișează informații despre echipa de dezvoltare a aplicației
            ViewData["Message"] = "Informații despre echipa noastră";
            return View();
        }

        // Acțiunea pentru contact
        public IActionResult Contact()
        {
            // Afișează o pagină de contact
            ViewData["Message"] = "Contactați-ne pentru orice întrebări";
            return View();
        }
        
        // Acțiunea pentru pagină de eroare personalizată
        public IActionResult Error()
        {
            return View();
        }
    }
}
