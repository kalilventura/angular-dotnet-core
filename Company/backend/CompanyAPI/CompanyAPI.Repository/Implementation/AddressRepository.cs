using CompanyAPI.Database.Context;
using CompanyAPI.Domain.Models;
using CompanyAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyAPI.Repository.Implementation
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(CompanyApiContext context) : base(context) { }
    }
}
