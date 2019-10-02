using CompanyAPI.Domain.Models;
using CompanyAPI.Repository.Interfaces;
using CompanyAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyAPI.Services.Implementation
{
    public class BaseService<T> : IBaseService<T> where T : Entity
    {
        private readonly IGenericRepository<T> _repository;

        public BaseService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> Add(T entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task<T> Alter(T entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public void Delete(T entity)
        {
            _repository.DeleteAsync(entity);
        }

        public async Task<bool> Exists(int id)
        {
            return await _repository.Exists(id);
        }

        public async Task<IList<T>> GetAll()
        {
            return await _repository.FindAll();
        }

        public async Task<T> GetById(int id)
        {
            return await _repository.GetById(id);
        }
    }
}
