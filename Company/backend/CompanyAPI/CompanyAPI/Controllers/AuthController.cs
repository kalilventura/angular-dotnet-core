using CompanyAPI.Domain.ViewModel;
using CompanyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Register([FromBody] UserViewModel user)
        {
            _authService.register(user);
            return Ok();
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserViewModel user)
        {
            _authService.login(user);

            return Ok();
        }

        private string GenerateToken(UserViewModel user)
        {
            return _authService.generateToken(user);
        }
    }
}