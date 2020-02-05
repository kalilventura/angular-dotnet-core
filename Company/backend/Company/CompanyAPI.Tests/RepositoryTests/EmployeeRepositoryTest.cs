using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyAPI.Database.Context;
using CompanyAPI.Domain.Models;
using CompanyAPI.Repository.Implementation;
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

            var moqRepository = ReturnMoqEmployeeRepository();

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
                new Employee("Fulano", "Document", "fulano@gmail.com"),
                new Employee("Ciclano", "Document", "ciclano@gmail.com")
            };

            var moqRepository = ReturnMoqEmployeeRepository();

            // When
            foreach (var employee in employees)
                await moqRepository.AddAsync(employee);

            var result = await moqRepository.FindOne(x => x.Name == "Fulano");

            //Then
            Assert.NotNull(result);
            Assert.Contains("Fulano", result.Name);

        }

        [Fact]
        public async Task GetEmployeeById()
        {
            // Given
            var employee = new Employee
            {
                Id = 10,
                Name = "Fulano",
                Document = "Document",
                Email = "fulano@gmail.com"
            };

            var moqRepository = ReturnMoqEmployeeRepository();

            // When
            await moqRepository.AddAsync(employee);

            var result = moqRepository.FindOne(x => x.Id == 10);

            // Then
            Assert.NotNull(result);
        }

        private EmployeeRepository ReturnMoqEmployeeRepository()
        {
            var options = new DbContextOptionsBuilder<CompanyApiContext>()
                                .UseInMemoryDatabase("CompanyDb").Options;
            var context = new CompanyApiContext(options);
            var moqRepository = new EmployeeRepository(context);

            return moqRepository;
        }
    }
}
