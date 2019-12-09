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
        Task<T> GetById(int? id);
        Task<bool> Exists(int? id);
        Task<IList<T>> FindAll();
        Task<IList<T>> Find(Expression<Func<T, bool>> query);
        Task<T> FindOne(Expression<Func<T, bool>> query);
    }
}
