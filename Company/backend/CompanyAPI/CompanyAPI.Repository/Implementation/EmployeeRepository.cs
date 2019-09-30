using System.Linq;
using System.Threading.Tasks;
using CompanyAPI.Database.Context;
using CompanyAPI.Domain.Models;
using CompanyAPI.Repository.Interfaces;

namespace CompanyAPI.Repository.Implementation
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CompanyApiContext context) : base(context) { }

        public async Task<Employee> FindByName(string name)
        {
            return _context.Employees.FirstOrDefault(x => x.Name.Equals(name));
        }
    }
}
