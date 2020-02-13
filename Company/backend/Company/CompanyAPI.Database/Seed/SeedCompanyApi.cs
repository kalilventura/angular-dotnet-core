using CompanyAPI.Database.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CompanyAPI.Database.Seed
{
    public class SeedCompanyApi
    {
        private readonly CompanyApiContext _context;

        public SeedCompanyApi(CompanyApiContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            if (!(_context.RoleClaims.Any()))
            {

                var claim = new[]
                {
                    new IdentityRoleClaim<string>
                    {
                        ClaimType = "Employee",
                        ClaimValue = "Employee",
                        Id = 1
                    },
                    new IdentityRoleClaim<string>
                    {
                        ClaimType = "Admin",
                        ClaimValue = "Admin",
                        Id = 2
                    }
                };

                _context.RoleClaims.AddRange(claim);
                _context.SaveChanges();
            }
        }
    }
}
