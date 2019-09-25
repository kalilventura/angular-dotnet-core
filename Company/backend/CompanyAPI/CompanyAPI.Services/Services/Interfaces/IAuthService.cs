using CompanyAPI.Domain.ValueObjects;
using CompanyAPI.Domain.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CompanyAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginUser> Login(LoginViewModel user);
        Task<IdentityResult> Register(UserViewModel user);
        Task<bool> UserExists(string UserName);
        Task<SignInResult> UserSignIn(LoginViewModel login);
    }
}
