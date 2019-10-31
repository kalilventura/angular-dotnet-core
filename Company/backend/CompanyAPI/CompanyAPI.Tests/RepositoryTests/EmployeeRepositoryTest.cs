using CompanyAPI.Database.Context;
using CompanyAPI.Domain.Models;
using CompanyAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CompanyAPI.Tests.RepositoryTests
{
    public class EmployeeRepositoryTest
    {
        private readonly IEmployeeRepository _mockRepository;
        private readonly DbSet<Employee> _mockEmployees;
        private readonly CompanyApiContext _mockContext;

        public EmployeeRepositoryTest()
        {
            _mockRepository = Substitute.For<IEmployeeRepository>();

        }

        [Fact]
        public void AddEmployee()
        {
            int counter = 0;
            var employee = new Employee("Teste","Document","email@email.com");
            //_mockRepository.AddAsync(employee);
            _mockRepository.When(x => x.AddAsync(employee)).Do(x => counter++);
            Assert.Equal(1, counter);
        }
    }
}
