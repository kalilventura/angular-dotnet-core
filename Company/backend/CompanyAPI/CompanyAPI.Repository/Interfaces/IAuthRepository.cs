using CompanyAPI.Domain.ValueObjects;
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
        Task<IdentityResult> CreateUser(UserViewModel user);
        Task<bool> userExists(UserViewModel user);
        Task<ApplicationUser> FindUserByEmail(string email);
        Task<ClaimsIdentity> GetUserClaims(ApplicationUser user);
        Task<SignInResult> SignIn(UserViewModel user);
    }
}
