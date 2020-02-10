using CompanyAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CompanyAPI.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        void DeleteAsync(T entity);
        Task<IEnumerable<T>> FindAll();
        Task<bool> Exists(Expression<Func<T, bool>> query);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> query);
        Task<T> FindOne(Expression<Func<T, bool>> query);
    }
}
