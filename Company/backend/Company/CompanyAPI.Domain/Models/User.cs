using CompanyAPI.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace CompanyAPI.Domain.ViewModel
{
    public class User : IdentityUser
    {
        public User(string password, string role, string fullName, Employee employee, string token)
        {
            Password = password;
            Role = role;
            FullName = fullName;
            Employee = employee;
            Token = token;
        }

        public string Password { get; private set; }
        public string Role { get; private set; }
        public string FullName { get; private set; }
        public Employee Employee { get; private set; }
        public string Token { get; private set; }
    }
}
