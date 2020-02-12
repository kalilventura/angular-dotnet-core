using CompanyAPI.Configuration;
using CompanyAPI.Database.Context;
using CompanyAPI.Domain.Models;
using CompanyAPI.Middleware;
using CompanyAPI.Shared.Settings;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CompanyAPI
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
            //Inject AppSettings
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            // Database
            services
                .AddDbContext<CompanyApiContext>(option =>
                   option.UseSqlServer(Configuration["ConnectionStrings:CompanyContext"],
                       m => m.MigrationsAssembly("CompanyAPI.Database")));

            //InMemory Database
            // services
            //     .AddDbContext<CompanyApiContext>(option =>
            //        option.UseInMemoryDatabase("CompanyDatabase"));

            services
                .AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<CompanyApiContext>();

            // DI
            services.RegisterRepositoryServices();

            //Validators
            services.RegisterValidators();

            //Jwt Authentication
            JsonWebTokenConfiguration.RegisterJwt(services, Configuration);

            // Swagger configurations
            services.RegisterSwagger();

            services.AddCors();
            services
                .AddControllers()
                .AddFluentValidation();

            services.RegisterRequestState();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                CompanyApiSeed.SeedAsync(app).Wait();
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandlerMiddleware();

            app
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Company V1");
                });

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x =>
            {
                x.AllowAnyOrigin();
                x.AllowAnyMethod();
                x.AllowAnyHeader();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}