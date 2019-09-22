using Microsoft.AspNetCore.Identity;

namespace CompanyAPI.Domain.ValueObjects
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
