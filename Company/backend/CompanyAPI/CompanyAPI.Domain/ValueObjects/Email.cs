using System.ComponentModel.DataAnnotations;

namespace CompanyAPI.Domain.ValueObjects
{
    public class Email
    {
        public Email()
        {

        }

        public Email(string address)
        {
            EmailAddress = address;
        }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string EmailAddress { get; private set; }

    }
}
