using CompanyAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CompanyAPI.Repository.Queries
{
    public static class EmployeeQueries
    {
        public static Expression<Func<Employee, bool>> EmployeeExists(int id) => x => x.Id == id;

    }
}
