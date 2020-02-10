using CompanyAPI.Domain.Models;
using CompanyAPI.Repository.Interfaces;
using CompanyAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CompanyAPI.Services.Implementation
{
    public class BaseService<T> : IBaseService<T> where T : Entity
    {
        protected readonly IGenericRepository<T> _repository;

        public BaseService(IGenericRepository<T> repository) => _repository = repository;

        public async Task<T> Add(T entity) => await _repository.AddAsync(entity);

        public async Task<T> Alter(T entity) => await _repository.UpdateAsync(entity);

        public void Delete(T entity) => _repository.DeleteAsync(entity);

        public async Task<bool> Exists(Expression<Func<T, bool>> query) => await _repository.Exists(query);

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> query) => await _repository.Find(query);

        public async Task<T> FindOne(Expression<Func<T, bool>> query) => await _repository.FindOne(query);

        public async Task<IEnumerable<T>> GetAll() => await _repository.FindAll();
    }
}
