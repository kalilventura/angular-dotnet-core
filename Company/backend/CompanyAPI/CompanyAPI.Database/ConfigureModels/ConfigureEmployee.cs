using CompanyAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyAPI.Database.ConfigureModels
{
    public class ConfigureEmployee : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .ToTable("Employees")
                .HasKey(h => h.Id)
                .HasName("EmployeeId");

            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(400);

            builder
                .Property(p => p.Document)
                .IsRequired()
                .HasMaxLength(12);

            builder
                .Property(p => p.Email)
                .HasMaxLength(400);

        }
    }
}
