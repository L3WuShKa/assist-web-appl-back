using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        // POST: api/auth/signup/organizationadmin
        [HttpPost("signup/organizationadmin")]
        public IActionResult SignUpOrganizationAdmin([FromBody] OrganizationAdminSignUpRequest request)
        {
            _authService.SignUpOrganizationAdmin(request);
            return Ok("Organization admin account created successfully.");
        }

        // GET: api/auth/signup/employee/url
        [HttpGet("signup/employee/url")]
        public IActionResult GetEmployeeSignUpURL(string organizationName)
        {
            string signUpURL = _authService.GenerateEmployeeSignUpURL(organizationName);
            return Ok(new { SignUpURL = signUpURL });
        }

        // POST: api/auth/signup/employee
        [HttpPost("signup/employee")]
        public IActionResult SignUpEmployee([FromBody] EmployeeSignUpRequest request)
        {
            _authService.SignUpEmployee(request);
            return Ok("Employee account created successfully.");
        }
    }
}
