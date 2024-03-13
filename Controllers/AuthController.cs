// AuthController.cs

/* Autentificarea și înregistrarea utilizatorilor: Furnizează endpoint-uri pentru înregistrare și autentificare, verificând și procesând datele furnizate de utilizatori.

Generarea și returnarea token-urilor JWT: Generează token-uri de autentificare JWT pentru utilizatorii validați și le returnează către client pentru autentificare ulterioară.

Protecția cu autorizare: Asigură că doar utilizatorii autentificați pot accesa resursele protejate, adăugând atributul [Authorize] la endpoint-urile corespunzătoare.

Gestionarea răspunsurilor HTTP: Returnează răspunsuri HTTP corespunzatoare ppentru indica rezultatul fiecărei operațiuni (înregistrare, autentificare) către client.
*/
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TeamFinder.Models;
using TeamFinder.Services;

namespace TeamFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterModel model)
        {
            var result = await _authService.RegisterAsync(model);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel model)
        {
            var result = await _authService.LoginAsync(model);

            if (!result.Success)
            {
                return Unauthorized();
            }

            return Ok(result.Data);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return Ok("Logged out successfully");
        }
    }
}
