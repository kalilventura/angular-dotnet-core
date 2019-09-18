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

        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public virtual ICollection<EmployeeAddresses> EmployeeAddresses { get; private set; }
    }
}
