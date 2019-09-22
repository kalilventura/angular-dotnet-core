using CompanyAPI.Domain.Models;
using CompanyAPI.Domain.ValueObjects;
using CompanyAPI.Domain.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CompanyAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginUser> login(UserViewModel user);
        bool isAuthorized(UserViewModel user);
        bool isAuthenticaded(UserViewModel user);
        Task<IdentityResult> register(UserViewModel user);
    }
}
