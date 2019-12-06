using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyAPI.Database.Context;
using CompanyAPI.Domain.Models;
using CompanyAPI.Repository.Interfaces;
using EFCore.BulkExtensions;

namespace CompanyAPI.Repository.Implementation
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CompanyApiContext context) : base(context) { }

        public async Task AddManyEmployees(IList<Employee> employees)
        {
            await _context.BulkInsertAsync(employees);
        }

        public IList<Employee> Find(Func<Employee, bool> filter)
        {
            return _context.Employees.Where(filter).ToList();
        }

        public Employee FindByName(string name)
        {
            return _context.Employees.FirstOrDefault(x => x.Name.Equals(name));
        }
    }
}
