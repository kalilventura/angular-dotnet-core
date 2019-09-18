using API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Database.Configurations
{
    public static class ConfigurationsModels
    {
        public static void ModelConfigurateProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(model =>
            {
                model.ToTable("Products");

                model
                .HasKey(x => x.ProductId);

                model
                .Property(x => x.BarCode)
                .IsRequired()
                .HasColumnType("varchar(40)");

                model
                .Property(x => x.Description)
                .IsRequired()
                .HasColumnType("varchar(40)");

                model
                .Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(40)");

                model
                .Property(x => x.Price)
                .IsRequired()
                .HasColumnType("real");
            });

        }

        public static void ModelConfigurateSellers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seller>(model =>
            {
                model.ToTable("Sellers");

                model
                .HasKey(x => x.SellerId);

                model
                    .Property(x => x.Name)
                    .IsRequired()
                    .HasColumnType("varchar(40)");

                model
                    .Property(x => x.CommissionValue)
                    .IsRequired()
                    .HasColumnType("real");

                model
                    .Property(x => x.Telephone)
                    .HasColumnType("varchar(10)")
                    .IsRequired()
                    .HasMaxLength(9);
            });
        }

        public static void ModelConfigurateSellerProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SellerProducts>()
                .HasKey(vp => new { vp.ProductId, vp.SellerId });
        }

    }
}
