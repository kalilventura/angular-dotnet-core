﻿using CompanyAPI.Domain.Models;
using CompanyAPI.Repository.Interfaces;
using CompanyAPI.Services.Implementation;
using CompanyAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyAPI.Services.Services.Implementation
{
    public class AddressService : BaseService<Address>, IAddressService
    {
        public AddressService(IGenericRepository<Address> repository) : base(repository) { }
    }
}
