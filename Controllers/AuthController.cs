// AuthController.cs

/* Autentificarea și înregistrarea utilizatorilor: Furnizează endpoint-uri pentru înregistrare și autentificare, verificând și procesând datele furnizate de utilizatori.

Generarea și returnarea token-urilor JWT: Generează token-uri de autentificare JWT pentru utilizatorii validați și le returnează către client pentru autentificare ulterioară.

Protecția cu autorizare: Asigură că doar utilizatorii autentificați pot accesa resursele protejate, adăugând atributul [Authorize] la endpoint-urile corespunzătoare.

Gestionarea răspunsurilor HTTP: Returnează răspunsuri HTTP corespunzatoare ppentru indica rezultatul fiecărei operațiuni (înregistrare, autentificare) către client.
*/

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using YourBackendProject.Models;

namespace YourBackendProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        /// <summary>
        /// Endpoint pentru înregistrarea unui utilizator.
        /// </summary>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            // Validare model și creare obiect IdentityUser
            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Utilizator înregistrat cu succes, generare token JWT
                var token = GenerateJwtToken(user);
                return Ok(new { Token = token });
            }

            return BadRequest(new { Message = "Registration failed", Errors = result.Errors });
        }

        /// <summary>
        /// Endpoint pentru autentificarea unui utilizator.
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            // Autentificare utilizator
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // Utilizator autentificat cu succes, generare token JWT
                var user = await _userManager.FindByEmailAsync(model.Email);
                var token = GenerateJwtToken(user);
                return Ok(new { Token = token });
            }

            return Unauthorized(new { Message = "Invalid credentials" });
        }

        // Metoda pentru generarea token-ului JWT
        private string GenerateJwtToken(IdentityUser user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["Jwt:ExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
