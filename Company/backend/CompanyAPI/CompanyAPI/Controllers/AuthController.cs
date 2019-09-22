using CompanyAPI.Domain.ViewModel;
using CompanyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

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
        [Route("Register")]
        public async Task<IActionResult> Register(UserViewModel user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
            try
            {
                await _authService.register(user);

                return Ok(new { message = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserViewModel user)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

                var login = await _authService.login(user);

                return Ok(new { login });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}