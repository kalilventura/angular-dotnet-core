using CompanyAPI.Database.Context;
using CompanyAPI.Domain.Models;
using CompanyAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyAPI.Repository.Implementation
{
    public class EmployeeAddressRepository : GenericRepository<EmployeeAddress>, IEmployeeAddressRepository
    {
        public EmployeeAddressRepository(CompanyApiContext context) : base(context) {}
    }
}
