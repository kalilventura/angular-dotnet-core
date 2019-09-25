using CompanyAPI.Domain.ViewModel;
using CompanyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserViewModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

                bool userExists = await _authService.UserExists(user.UserName);

                if (userExists)
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "User exists." });

                await _authService.Register(user);

                return StatusCode(StatusCodes.Status201Created ,new { message = "User successfully registered." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

                bool userExists = await _authService.UserExists(user.UserName);

                if (!userExists)
                    return StatusCode(StatusCodes.Status404NotFound, new { message = "Username not exists." });

                var signInUser = await _authService.UserSignIn(user);

                if (!signInUser.Succeeded)
                    return StatusCode(StatusCodes.Status401Unauthorized, new { message = "Wrong username or password." });

                var login = await _authService.Login(user);

                return StatusCode(StatusCodes.Status202Accepted, new { login });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}