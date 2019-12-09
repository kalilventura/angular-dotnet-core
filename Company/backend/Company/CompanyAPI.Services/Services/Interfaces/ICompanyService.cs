using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyAPI.Domain.Models;

namespace CompanyAPI.Services.Interfaces
{
    public interface ICompanyService : IBaseService<Company>
    {
        Task<IList<Company>> GetByCompanyName(string companyName);
    }
}
