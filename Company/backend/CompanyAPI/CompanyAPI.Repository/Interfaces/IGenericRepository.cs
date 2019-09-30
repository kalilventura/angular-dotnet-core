using CompanyAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyAPI.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        void DeleteAsync(T entity);
        Task<T> GetById(int id);
        Task<bool> Exists(int id);
        Task<IList<T>> FindAll();
    }
}
