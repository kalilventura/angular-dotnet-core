using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CompanyAPI.Configuration
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(swagger =>
                        {
                            swagger.SwaggerDoc("v1", new OpenApiInfo
                            {
                                Title = "Company API",
                                Version = "v1",
                                Description = "API using SQL Server and ASP.Net Core 3.1",
                                Contact = new OpenApiContact
                                {
                                    Name = "Kalil Teixeira Ventura Monteiro",
                                    Email = "kalilventur@gmail.com",
                                    //Url = new Uri("")
                                },
                                License = new OpenApiLicense
                                {
                                    Name = "Use MIT License",
                                    //Url = new Uri("")
                                }
                            });
                            swagger.ResolveConflictingActions(x => x.First());
                            swagger.AddSecurityDefinition("Bearer",
                                new OpenApiSecurityScheme
                                {
                                    Description = "Json Web Token Authorization header using Bearer Scheme",
                                    Name = "Authorization",
                                    In = ParameterLocation.Header,
                                    Type = SecuritySchemeType.ApiKey
                                }
                            );
                            swagger.AddSecurityRequirement(
                                new OpenApiSecurityRequirement {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }
                                }
                            );
                        });

            return services;
        }
    }
}