using System;
using System.Collections.Generic;
using System.Text;
using CompanyAPI.Database.Context;
using CompanyAPI.Domain.Models;
using CompanyAPI.Repository.Implementation;
using CompanyAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Xunit;

namespace CompanyAPI.Tests.RepositoryTests {
    public class EmployeeRepositoryTest {
        private readonly IEmployeeRepository _mockRepository;
        private readonly DbSet<Employee> _mockEmployees;
        private readonly CompanyApiContext _mockContext;

        public EmployeeRepositoryTest () {
            _mockEmployees = Substitute.For<DbSet<Employee>> ();
            _mockContext = Substitute.For<CompanyApiContext> ();
            _mockContext.Employees.Returns(_mockEmployees);
            _mockRepository = new EmployeeRepository(_mockContext);
        }

        [Fact]
        public void AddEmployee () {
            var employee = new Employee ("Teste", "Document", "email@email.com");
            _mockRepository.AddAsync(employee);
            _mockEmployees.Received(1).Add(Arg.Any<Employee>());
            _mockContext.Received(1).SaveChangesAsync();
        }
    }
}
