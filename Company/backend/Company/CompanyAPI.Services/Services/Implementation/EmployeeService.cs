using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyAPI.Domain.Models;
using CompanyAPI.Repository.Interfaces;
using CompanyAPI.Services.Interfaces;

namespace CompanyAPI.Services.Implementation
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        public EmployeeService(IGenericRepository<Employee> company): base(company) { }

        public async Task<IList<Employee>> FindByName(string name)
        {
            return await _repository.Find(x => x.Name.Contains(name));
        }
    }
}
