using CompanyAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyAPI.Database.ConfigureModels
{
    //public class ConfigureEmployeeAddress : IEntityTypeConfiguration<EmployeeAddress>
    //{
    //    public void Configure(EntityTypeBuilder<EmployeeAddress> builder)
    //    {
    //        builder.HasKey(e => new { e.AddressId, e.EmployeeId });

    //        builder
    //            .HasOne(x => x.Employee)
    //            .WithMany(x => x.Addresses)
    //            .HasForeignKey(y => y.EmployeeId);

    //        builder
    //            .HasOne(x => x.Address)
    //            .WithMany(x => x.Employee)
    //            .HasForeignKey(y => y.AddressId);
    //    }
    //}
}
