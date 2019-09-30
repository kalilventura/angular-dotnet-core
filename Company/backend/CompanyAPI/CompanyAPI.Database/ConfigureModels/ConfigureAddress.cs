using CompanyAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyAPI.Database.ConfigureModels
{
    public class ConfigureAddress : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .ToTable("Addresses")
                .HasKey(key => key.Id)
                .HasName("AddressId");

            builder
                .Property(x => x.City)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(x => x.Complement)
                .HasMaxLength(200);

            builder
                .Property(x => x.Country)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(x => x.District)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(x => x.Number)
                .IsRequired()
                .HasMaxLength(10);

            builder
                .Property(x => x.State)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(x => x.Street)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(x => x.Type)
                .IsRequired()
                .HasMaxLength(10);

            builder
                .Property(x => x.ZipCode)
                .IsRequired()
                .HasMaxLength(13);

        }
    }
}
