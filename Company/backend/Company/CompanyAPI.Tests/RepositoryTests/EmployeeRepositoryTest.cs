using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CompanyAPI.Database.Context;
using CompanyAPI.Domain.Models;
using CompanyAPI.Repository.Implementation;
using CompanyAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace CompanyAPI.Tests.RepositoryTests
{
    public class EmployeeRepositoryTest
    {
        public EmployeeRepositoryTest() { }

        [Fact]
        public async Task AddEmployeeAsync()
        {
            var employee = new Employee("Teste", "Document", "email@email.com");

            var options = new DbContextOptionsBuilder<CompanyApiContext>()
                                    .UseInMemoryDatabase("CompanyDb")
                                    .Options;

            var moqContext = new Mock<CompanyApiContext>(options);
            var moqRepository = new EmployeeRepository(moqContext.Object);

            await moqRepository.AddAsync(employee);

            var resultado = await moqRepository.Find(x => x.Document.Equals(employee.Document));

            Assert.NotNull(resultado);
            Assert.NotEmpty(resultado);
        }

        [Fact]
        public async Task FindEmployeeByName()
        {
            //Given
            var employees = new List<Employee>
            {
                new Employee("Kalil", "Document", "kalil@gmail.com"),
                new Employee("Fulano", "Document", "fulano@gmail.com"),
                new Employee("Ciclano", "Document", "ciclano@gmail.com"),
                new Employee("Beltrano", "Document", "beltrano@gmail.com")
            };

            var options = new DbContextOptionsBuilder<CompanyApiContext>()
                                    .UseInMemoryDatabase("CompanyDb")
                                    .Options;

            var moqContext = new Mock<CompanyApiContext>(options);
            var moqRepository = new EmployeeRepository(moqContext.Object);

            //When
            await moqRepository.AddManyEmployees(employees);
            var result = await moqRepository.FindOne(x => x.Name == "Fulano");

            //Then
            Assert.NotNull(result);
            Assert.Contains("Fulano", result.Name);
        }
    }
}
