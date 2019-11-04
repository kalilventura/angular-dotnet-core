using CompanyAPI.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace CompanyAPI.Domain.ViewModel
{
    public class User : IdentityUser
    {
        public string Password { get; set; }

        public string Role { get; set; }

        public string FullName { get; set; }

        public Employee Employee { get; set; }

        public string Token { get; set; }
    }
}
