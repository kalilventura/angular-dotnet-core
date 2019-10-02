using CompanyAPI.Domain.Models;
using CompanyAPI.Repository.Interfaces;
using CompanyAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyAPI.Services.Implementation
{
    public class EmployeeAddressService : BaseService<EmployeeAddress>, IEmployeeAddressService
    {
        public EmployeeAddressService(IGenericRepository<EmployeeAddress> repository) : base(repository) { }
    }
}
