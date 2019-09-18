using System;
using System.Threading.Tasks;
using login_webapi.Database.Context;
using login_webapi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace login_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Auth : ControllerBase
    {
        private readonly DatabaseContext _context;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public Auth(DatabaseContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<Object> PostApplicationUser(ApplicationUserModel model)
        {
            var appUser = new ApplicationUser()
            {
                UserName = model.Username,
                Email = model.Email,
                Fullname = model.Fullname,
            };

            try
            {
                var result = await _userManager.CreateAsync(appUser,model.Password);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}