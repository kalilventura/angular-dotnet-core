using System.Collections.Generic;

namespace CompanyAPI.Domain.Models
{
    public class Employee : Entity
    {
        public Employee()
        {

        }
        public Employee(string name, string document, string email)
        {
            Name = name;
            Document = document;
            Email = email;
        }

        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public virtual List<EmployeeAddress> Addresses { get; set; }
    }
}
