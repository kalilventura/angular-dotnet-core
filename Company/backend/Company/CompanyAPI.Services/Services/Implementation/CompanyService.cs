using CompanyAPI.Domain.Models;
using CompanyAPI.Repository.Interfaces;
using CompanyAPI.Services.Interfaces;

namespace CompanyAPI.Services.Implementation
{
    public class CompanyService : BaseService<Company>, ICompanyService
    {
        public CompanyService(IGenericRepository<Company> repository) : base(repository) { }
    }
}
