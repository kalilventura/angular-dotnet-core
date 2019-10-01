using CompanyAPI.Domain.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CompanyAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> Login(Login user);
        Task<IdentityResult> Register(User user);
        Task<bool> UserExists(string UserName);
        Task<bool> EmailExists(string Email);
        Task<SignInResult> UserSignIn(Login login);
    }
}
