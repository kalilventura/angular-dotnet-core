using CompanyAPI.Domain.Models;

namespace CompanyAPI.Domain.ValueObjects
{
    public class LoginUser
    {
        public Employee Employee { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
