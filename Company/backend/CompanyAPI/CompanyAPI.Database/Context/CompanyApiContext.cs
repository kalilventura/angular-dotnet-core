using CompanyAPI.Database.ConfigureModels;
using CompanyAPI.Domain.Models;
using CompanyAPI.Domain.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Database.Context
{
    public class CompanyApiContext : IdentityDbContext
    {
        public CompanyApiContext(DbContextOptions<CompanyApiContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<EmployeeAddresses> EmployeeAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Employee>(new ConfigureEmployee());
            modelBuilder.ApplyConfiguration<Address>(new ConfigureAddress());
            modelBuilder.ApplyConfiguration<Company>(new ConfigureCompany());
            modelBuilder.ApplyConfiguration<EmployeeAddresses>(new ConfigureEmployeeAddress());
            base.OnModelCreating(modelBuilder);
        }
    }
}
