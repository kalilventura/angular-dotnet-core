using System;
using System.Security.Claims;
using System.Threading.Tasks;
using CompanyAPI.Domain.ValueObjects;
using CompanyAPI.Domain.ViewModel;
using CompanyAPI.Repository.Interfaces;
using CompanyAPI.Shared.Settings;
using Microsoft.AspNetCore.Identity;

namespace CompanyAPI.Repository.Implementation
{
    public class AuthRepository : IAuthRepository
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AuthRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUser(UserViewModel user)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = user.UserName,
                Email = user.Email
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser, user.Password);
                // await _userManager.AddToRoleAsync(applicationUser, user.Role);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create user.",ex.InnerException);
            }

        }

        public async Task<ApplicationUser> FindUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<ClaimsIdentity> GetUserClaims(ApplicationUser user)
        {
            try
            {
                ClaimsIdentity identityClaims = new ClaimsIdentity();
                identityClaims.AddClaims(await _userManager.GetClaimsAsync(user));

                return identityClaims;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SignInResult> SignIn(UserViewModel user)
        {
            return await _signInManager
                .PasswordSignInAsync(user.Email, user.Password, isPersistent: false, lockoutOnFailure: true);
        }

        public async Task<bool> userExists(UserViewModel user)
        {
            try
            {
                var result = await _userManager.FindByEmailAsync(user.Email);

                return result != null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
