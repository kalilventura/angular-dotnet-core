using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyAPI.Domain.Models;

namespace CompanyAPI.Services.Interfaces
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        Task<IList<Employee>> FindByName(string name);
    }
}
