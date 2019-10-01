using Microsoft.AspNetCore.Identity;

namespace CompanyAPI.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
