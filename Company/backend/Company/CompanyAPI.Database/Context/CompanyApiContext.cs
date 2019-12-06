using CompanyAPI.Database.ConfigureModels;
using CompanyAPI.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Database.Context
{
    public class CompanyApiContext : IdentityDbContext
    {
        public CompanyApiContext() { }
        public CompanyApiContext(DbContextOptions<CompanyApiContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<EmployeeAddress> EmployeesAddresses { get; set; }

        // Identity
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration<Employee>(new ConfigureEmployee());
            //modelBuilder.ApplyConfiguration<Company>(new ConfigureCompany());
            //modelBuilder.ApplyConfiguration<Address>(new ConfigureAddress());
            modelBuilder.ApplyConfiguration<EmployeeAddress>(new ConfigureEmployeeAddress());
            base.OnModelCreating(modelBuilder);
        }
    }
}