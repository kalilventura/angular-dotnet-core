using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyAPI.Domain.Models;
using CompanyAPI.Repository.Interfaces;
using CompanyAPI.Services.Interfaces;

namespace CompanyAPI.Services.Implementation
{
    public class CompanyService : BaseService<Company>, ICompanyService
    {
        public CompanyService(IGenericRepository<Company> repository) : base(repository) { }

        public async Task<IList<Company>> GetByCompanyName(string companyName)
        {
            return await _repository.Find(x => x.CompanyName == companyName);
        }
    }
}
