using CompanyAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAPI.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> FindByName(string name);
    }
}
