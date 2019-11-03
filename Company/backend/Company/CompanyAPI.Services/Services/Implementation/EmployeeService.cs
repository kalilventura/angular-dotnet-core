using CompanyAPI.Domain.Models;
using CompanyAPI.Repository.Interfaces;
using CompanyAPI.Services.Interfaces;

namespace CompanyAPI.Services.Implementation
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        public EmployeeService(IGenericRepository<Employee> company): base(company) { }
    }
}
