using CompanyAPI.Database.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace CompanyAPI.Database.Context
{
    public class CompanyApiSeed
    {
        public static async Task SeedAsync(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var scopeServiceProvider = serviceScope.ServiceProvider;
                var context = serviceScope.ServiceProvider.GetService<CompanyApiContext>();
<<<<<<< HEAD
                context.Database.Migrate();

                //new SeedCompanyApi(context).Seed();
=======
                await context.Database.MigrateAsync();
>>>>>>> 5f6d46ddf1be1b34305806b0c559bff95a1401f1
            }
        }
    }
}