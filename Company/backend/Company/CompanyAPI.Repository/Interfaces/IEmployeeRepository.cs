using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyAPI.Domain.Models;

namespace CompanyAPI.Repository.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Employee FindByName(string name);
        IList<Employee> Find(Func<Employee, bool> filter);
        Task AddManyEmployees(IList<Employee> employees);
    }
}
