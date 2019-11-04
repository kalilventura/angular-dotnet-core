using System.Threading.Tasks;
using CompanyAPI.Domain.Models;
using CompanyAPI.Domain.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace CompanyAPI.Services.Interfaces {
    public interface IAuthService {
        Task<User> Login (Login user);
        Task<IdentityResult> Register (Register user);
        Task<bool> UserExists (string UserName);
        Task<bool> EmailExists (string Email);
        Task<SignInResult> UserSignIn (Login login);
    }
}