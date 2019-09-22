using System.ComponentModel.DataAnnotations;

namespace CompanyAPI.Domain.ViewModel
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        [DataType(DataType.Password,ErrorMessage = "Senha incorreta")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        public string UserName { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
    }
}
