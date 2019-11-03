using CompanyAPI.Domain.Models;
using CompanyAPI.Domain.Validations;
using CompanyAPI.Domain.ViewModel;
using CompanyAPI.Repository.Implementation;
using CompanyAPI.Repository.Interfaces;
using CompanyAPI.Services.Implementation;
using CompanyAPI.Services.Interfaces;
using CompanyAPI.Services.Services.Implementation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyAPI.Configuration {
    /// <summary>
    /// Classe criada para a configura��o do DI
    /// </summary>
    public static class ServiceRepositoryCollectionExtensions {
        /// <summary>
        /// M�todo criado para a inser��o dos servi�os e reposit�rios
        /// </summary>
        /// <param name="services">Servi�os da aplica��o</param>
        /// <returns></returns>
        public static IServiceCollection RegisterRepositoryServices (this IServiceCollection services) {

            //Services and Repositories
            services.AddScoped<IAuthService, AuthService> ();
            services.AddScoped<IAuthRepository, AuthRepository> ();

            services.AddScoped<ICompanyService, CompanyService> ();
            services.AddScoped<ICompanyRepository, CompanyRepository> ();

            services.AddScoped<IEmployeeService, EmployeeService> ();
            services.AddScoped<IEmployeeRepository, EmployeeRepository> ();

            services.AddScoped<IEmployeeAddressService, EmployeeAddressService> ();
            services.AddScoped<IEmployeeAddressRepository, EmployeeAddressRepository> ();

            services.AddScoped<IAddressService, AddressService> ();
            services.AddScoped<IAddressRepository, AddressRepository> ();

            //Generic Repository and Service
            services.AddScoped (typeof (IBaseService<>), typeof (BaseService<>));
            services.AddScoped (typeof (IGenericRepository<>), typeof (GenericRepository<>));

            return services;
        }

        /// <summary>
        /// Valida��o dos Modelos do projeto
        /// </summary>
        /// <param name="services">Servi�os da aplica��o</param>
        /// <returns></returns>
        public static IServiceCollection RegisterValidators (this IServiceCollection services) {
            services.AddTransient<IValidator<Login>, LoginValidator> ();
            services.AddTransient<IValidator<User>, UserValidator> ();
            services.AddTransient<IValidator<Address>, AddressValidator> ();
            services.AddTransient<IValidator<Company>, CompanyValidator> ();
            services.AddTransient<IValidator<Employee>, EmployeeValidator> ();
            services.AddTransient<IValidator<Register>, RegisterValidator> ();

            return services;
        }
    }
}