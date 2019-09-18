using CompanyAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyAPI.Database.ConfigureModels
{
    public class ConfigureCompany : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder
                .ToTable("Companies")
                .HasKey(x => x.Id)
                .HasName("CompanyId");

            builder
                .Property(x => x.CompanyName)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(x => x.Document)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
