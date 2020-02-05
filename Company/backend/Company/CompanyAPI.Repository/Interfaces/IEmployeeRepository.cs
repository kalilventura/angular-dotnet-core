using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyAPI.Domain.Models;

namespace CompanyAPI.Repository.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task AddManyEmployees(IList<Employee> employees);
    }
}
