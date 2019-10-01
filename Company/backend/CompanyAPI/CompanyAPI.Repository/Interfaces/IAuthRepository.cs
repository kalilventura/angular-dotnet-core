using CompanyAPI.Domain.Models;
using CompanyAPI.Domain.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAPI.Repository.Interfaces
{
    public interface IAuthRepository
    {
        Task<IdentityResult> CreateUser(User user);
        Task<bool> UserExists(string username);
        Task<bool> EmailExists(string email);
        Task<ApplicationUser> FindUserByUserName(string email);
        Task<ClaimsIdentity> GetUserClaims(ApplicationUser user);
        Task<SignInResult> SignIn(Login user);
    }
}
