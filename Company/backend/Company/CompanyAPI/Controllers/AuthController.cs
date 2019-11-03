using System.Threading.Tasks;
using CompanyAPI.Domain.Models;
using CompanyAPI.Domain.ViewModel;
using CompanyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Responsável pela criação do usuário
        /// </summary>
        /// <param name="user">Usuário que será criado</param>
        /// <returns></returns>
        /// <response code="201">Usuário criado com sucesso</response>
        /// <response code="406">Usuário não aceito</response>
        /// <response code="500">Erro interno</response>
        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        [Produces("application/json")]
        [ProducesResponseType(201)]
        [ProducesResponseType(406)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Register(Register user)
        {
            bool userExists = await _authService.UserExists(user.Username);

            if (userExists)
                return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Username exists." });

            bool emailExists = await _authService.EmailExists(user.Email);

            if (emailExists)
                return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Email exists." });

            var isRegistered = await _authService.Register(user);

            if (!isRegistered.Succeeded)
                return StatusCode(StatusCodes.Status406NotAcceptable, new { message = isRegistered.Errors });

            return StatusCode(StatusCodes.Status201Created, new { message = "User successfully registered." });
        }

        /// <summary>
        /// Responsável pelo login do usuário
        /// </summary>
        /// <param name="user">Usuario que está entrando no sistema.</param>
        /// <returns></returns>
        /// <response code="202">Usuário logado com sucesso</response>
        /// <response code="401">Usuário não autorizado</response>
        /// <response code="404">Usuário não encontrado</response>
        /// <response code="500">Erro interno</response>
        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        [Produces("application/json")]
        [ProducesResponseType(202)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Login(Login user)
        {
            bool userExists = await _authService.UserExists(user.UserName);

            if (!userExists)
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Username not exists." });

            var signInUser = await _authService.UserSignIn(user);

            if (!signInUser.Succeeded)
                return StatusCode(StatusCodes.Status401Unauthorized, new { message = "Wrong username or password." });

            var login = await _authService.Login(user);

            return StatusCode(StatusCodes.Status202Accepted, new { login });

        }
    }
}