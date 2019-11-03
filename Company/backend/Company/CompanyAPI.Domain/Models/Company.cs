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

        public string CompanyName { get; set; }

        public string Document { get; set; }
    }
}
