using CompanyAPI.Domain.ViewModel;

namespace CompanyAPI.Domain.Models
{
    public class Register
    {
        // public string Password { get; private set; }
        // public string Username { get; private set; }
        public Login Login { get; private set; }
        public string Email { get; private set; }
        public string FullName { get; private set; }
    }
}