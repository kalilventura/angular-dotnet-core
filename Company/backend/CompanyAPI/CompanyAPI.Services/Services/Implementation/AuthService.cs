using CompanyAPI.Domain.Models;
using CompanyAPI.Domain.ViewModel;
using CompanyAPI.Services.Interfaces;
using System;

namespace CompanyAPI.Services.Implementation
{
    public class AuthService : IAuthService
    {
        public string generateToken(UserViewModel user)
        {
            throw new NotImplementedException();
        }

        public bool isAuthenticaded(UserViewModel user)
        {
            throw new NotImplementedException();
        }

        public bool isAuthorized(UserViewModel user)
        {
            throw new NotImplementedException();
        }

        public Employee login(UserViewModel user)
        {
            throw new NotImplementedException();
        }

        public void logout()
        {
            throw new NotImplementedException();
        }

        public UserViewModel register(UserViewModel user)
        {
            throw new NotImplementedException();
        }

        public bool userExists(UserViewModel user)
        {
            throw new NotImplementedException();
        }
    }
}
