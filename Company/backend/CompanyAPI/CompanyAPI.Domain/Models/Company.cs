using System.ComponentModel.DataAnnotations;

namespace CompanyAPI.Domain.Models
{
    public class Company : Entity
    {
        public Company() { }

        public Company(string companyName, string document)
        {
            CompanyName = companyName;
            Document = document;
        }

        [Required(ErrorMessage = "The field {0} is required", AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "Invalid Company Name", MinimumLength = 6)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CompanyName { get; private set; }

        [Required(ErrorMessage = "The field {0} is required", AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "Invalid Document", MinimumLength = 6)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Document { get; private set; }
    }
}
