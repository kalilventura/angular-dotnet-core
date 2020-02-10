using CompanyAPI.Domain.Models;
using CompanyAPI.Repository.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CompanyAPI.Tests.QueriesTests
{
    public class EmployeeQueriesTest
    {
        private IEnumerable<Employee> employees;

        public EmployeeQueriesTest()
        {
            employees = CreateListEmployees();
        }

        [Fact]
        public void Find_Employee_By_Id_01()
        {
            var result = employees.AsQueryable().Where(EmployeeQueries.EmployeeExists(1));
            Assert.Equal(1, result.Count());
        }

        public IList<Employee> CreateListEmployees()
        {
            IList<Employee> employees = new List<Employee>();
            for (int i = 0; i <= 10; i++)
            {
                employees.Add(new Employee($"Teste{i}", $"document{i}", $"email{i}@email.com")
                {
                    Id = i
                });
            }

            return employees;
        }
    }
}
