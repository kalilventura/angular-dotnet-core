using CompanyAPI.Domain.Models;

namespace CompanyAPI.Repository.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Employee FindByName(string name);
    }
}
