using CompanyAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CompanyAPI.Services.Interfaces
{
    public interface IBaseService<T> where T : Entity
    {
        Task<T> Add(T entity);
        void Delete(T entity);
        Task<T> Alter(T entity);
        Task<IList<T>> GetAll();
        Task<bool> Exists(Expression<Func<T, bool>> query);
        Task<IList<T>> Find(Expression<Func<T, bool>> query);
        Task<T> FindOne(Expression<Func<T, bool>> query);
    }
}
