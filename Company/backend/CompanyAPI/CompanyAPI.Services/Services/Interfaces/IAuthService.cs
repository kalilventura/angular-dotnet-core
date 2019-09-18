
using CompanyAPI.Domain.Models;
using CompanyAPI.Domain.ViewModel;

namespace CompanyAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Employee login(UserViewModel user);
        void logout();
        bool isAuthorized(UserViewModel user);
        bool isAuthenticaded(UserViewModel user);
        UserViewModel register(UserViewModel user);
        string generateToken(UserViewModel user);
        bool userExists(UserViewModel user);
    }
}
