using CompanyAPI.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace CompanyAPI.Domain.ViewModel
{
    public class User
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The field {0} need between {2} and {1} characters.", MinimumLength = 6)]
        [DataType(DataType.Password,ErrorMessage = "Password Incorrect.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "The field {0} is required")]
        public string Username { get; set; }

        public string Role { get; set; }

        public string FullName { get; set; }

        public Employee Employee { get; set; }

        public string Token { get; set; }
    }
}
