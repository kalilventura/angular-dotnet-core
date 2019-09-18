using CompanyAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyAPI.Database.ConfigureModels
{
    public class ConfigureEmployeeAddress : IEntityTypeConfiguration<EmployeeAddresses>
    {
        public void Configure(EntityTypeBuilder<EmployeeAddresses> builder)
        {
            builder
                .ToTable("EmployeeAddresses");

            // NxN
            builder
                .HasKey(x => new { x.EmployeeId, x.AddressId});
        }
    }
}
