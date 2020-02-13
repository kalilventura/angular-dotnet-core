using System;
using System.Security.Claims;
using System.Threading.Tasks;
using CompanyAPI.Domain.Models;
using CompanyAPI.Domain.ViewModel;
using CompanyAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CompanyAPI.Repository.Implementation
{
    public class AuthRepository : IAuthRepository
    {
          private readonly UserManager<ApplicationUser> _userManager;
          private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthRepository(UserManager<ApplicationUser> userManager,
                              SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUser(Register user)
        {
            try
            {
                var applicationUser = new ApplicationUser()
                {
                    UserName = user.Username,
                    Email = user.Email,
                    FullName = user.FullName
                };

                var result = await _userManager.CreateAsync(applicationUser, user.Password);
                //await _userManager.AddToRoleAsync(applicationUser, "Employee");
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create user: {ex.Message}");
            }

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

        public async Task<SignInResult> SignIn(Login user)
        {
            return await _signInManager
                .PasswordSignInAsync(user.Username, user.Password, isPersistent: false, lockoutOnFailure: true);
        }

        public async Task<bool> UserExists(string username)
        {
            try
            {
                var result = await _userManager.FindByNameAsync(username);
                
                return result != null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> EmailExists(string email)
        {
            var result = await _userManager.FindByEmailAsync(email);

            return result != null;
        }

        public async Task<ApplicationUser> FindUserByUserName(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }
    }
}
