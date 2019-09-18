using Api.Repository.Interface;
using API.Database;
using API.Database.SeedingService;
using API.Domain.Models;
using API.Repository.Implementation;
using API.Repository.Interface;
using API.Validations.Business;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApiContext>(c => c.UseMySQL(Configuration["ConnectionStrings:MySQL"]));
            //Dependency Injection
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            // Add FluentValidator
            services.AddMvc(setup => { })
                .AddFluentValidation()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            // Validations
            services.AddTransient<IValidator<Seller>, SellerBusiness>();
            services.AddTransient<IValidator<Product>, ProductBusiness>();
            // Seeding Service
            services.AddScoped<SeedingService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeedingService seedingService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
                // Seed
                seedingService.SeedProducts();
                seedingService.SeedSellers();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseMvc();
        }
    }
}
