using System;
using System.Collections.Generic;

namespace CompanyAPI.Domain.Models
{
    public class Employee : Entity
    {
        public Employee() : base() { }

        public Employee(string name, string document, string email, Guid? id) : base(id)
        {
            Name = name;
            Document = document;
            Email = email;
        }

        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public virtual List<Address> Addresses { get; private set; }
    }
}
