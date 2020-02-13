using CompanyAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CompanyAPI.Repository.Queries
{
    public static class CompanyQueries
    {
        public static Expression<Func<Company, bool>> FindById(Guid? id) => x => x.Id == id;
        public static Expression<Func<Company, bool>> FindByName(string name) => x => x.CompanyName.Contains(name);
    }
}
