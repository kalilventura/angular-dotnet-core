using System;
using System.Text;
using CompanyAPI.Configuration;
using CompanyAPI.Database.Context;
using CompanyAPI.Domain.Models;
using CompanyAPI.Repository.Implementation;
using CompanyAPI.Repository.Interfaces;
using CompanyAPI.Services.Implementation;
using CompanyAPI.Services.Interfaces;
using CompanyAPI.Services.Services.Implementation;
using CompanyAPI.Shared.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace CompanyAPI {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            //Inject AppSettings
            services.Configure<ApplicationSettings> (Configuration.GetSection ("ApplicationSettings"));

            // Database
            services
                .AddDbContext<CompanyApiContext> (option =>
                    option.UseSqlServer (Configuration["ConnectionStrings:CompanyContext"],
                        m => m.MigrationsAssembly ("CompanyAPI.Database")));

            services
                .AddDefaultIdentity<ApplicationUser> ()
                .AddRoles<IdentityRole> ()
                .AddEntityFrameworkStores<CompanyApiContext> ();

            // DI
            services.RegisterRepositoryServices();

            //Jwt Authentication
            var key = Encoding.UTF8.GetBytes (Configuration["ApplicationSettings:JWT_Secret"].ToString ());
            services.AddAuthentication (x => {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer (x => {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuerSigningKey = false,
                        IssuerSigningKey = new SymmetricSecurityKey (key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddSwaggerGen (c => {
                c.SwaggerDoc ("v1", new OpenApiInfo {
                    Title = "Company API",
                        Version = "v1",
                        Description = "API using SQL Server and ASP.Net Core 3.0",
                });
            });

            services.AddControllers ();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app
                .UseSwagger ()
                .UseSwaggerUI (c => {
                    c.SwaggerEndpoint ("/swagger/v1/swagger.json", "Company V1");
                    c.RoutePrefix = string.Empty;
                });

            app
                .UseHttpsRedirection ()
                .UseRouting ()
                .UseAuthorization ()
                .UseCors (builder =>
                    builder
                    .AllowAnyOrigin ()
                    //.WithOrigins(Configuration["ApplicationSettings:Client_URL"].ToString())
                    .AllowAnyHeader ()
                    .AllowAnyMethod ()
                );

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }

    }
}