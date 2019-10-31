using CompanyAPI.Domain.Models;

namespace CompanyAPI.Domain.ViewModel
{
    public class User
    {
        public string Password { get; set; }

        public string Email { get; set; }
        
        public string Username { get; set; }

        public string Role { get; set; }

        public string FullName { get; set; }

        public Employee Employee { get; set; }

        public string Token { get; set; }
    }
}
