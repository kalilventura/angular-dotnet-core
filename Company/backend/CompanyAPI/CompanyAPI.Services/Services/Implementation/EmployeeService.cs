using CompanyAPI.Domain.Models;
using CompanyAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyAPI.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        public Task<Employee> Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> Alter(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
