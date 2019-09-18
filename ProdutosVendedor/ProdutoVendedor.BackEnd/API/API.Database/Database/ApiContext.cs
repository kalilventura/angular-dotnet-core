using API.Database.Configurations;
using API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Database
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<SellerProducts> SellerProducts { get; set; }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigurationsModels.ModelConfigurateProducts(modelBuilder);
            ConfigurationsModels.ModelConfigurateSellers(modelBuilder);
            ConfigurationsModels.ModelConfigurateSellerProducts(modelBuilder);
        }
    }
}
