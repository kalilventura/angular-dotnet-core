using System.Threading.Tasks;
using CompanyAPI.Domain.Models;
using CompanyAPI.Domain.ViewModel;
using CompanyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyAPI.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        readonly IAuthService _authService;

        public AuthController (IAuthService authService) {
            _authService = authService;
        }

        [HttpPost]
        [Route ("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register (Register user) {
            bool userExists = await _authService.UserExists (user.Username);

            if (userExists)
                return StatusCode (StatusCodes.Status406NotAcceptable, new { message = "Username exists." });

            bool emailExists = await _authService.EmailExists (user.Email);

            if (emailExists)
                return StatusCode (StatusCodes.Status406NotAcceptable, new { message = "Email exists." });

            var isRegistered = await _authService.Register (user);

            if (!isRegistered.Succeeded)
                return StatusCode (StatusCodes.Status406NotAcceptable, new { message = isRegistered.Errors });

            return StatusCode (StatusCodes.Status201Created, new { message = "User successfully registered." });
        }

        [HttpPost]
        [Route ("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login (Login user) {
            bool userExists = await _authService.UserExists (user.UserName);

            if (!userExists)
                return StatusCode (StatusCodes.Status404NotFound, new { message = "Username not exists." });

            var signInUser = await _authService.UserSignIn (user);

            if (!signInUser.Succeeded)
                return StatusCode (StatusCodes.Status401Unauthorized, new { message = "Wrong username or password." });

            var login = await _authService.Login (user);

            return StatusCode (StatusCodes.Status202Accepted, new { login });

        }
    }
}