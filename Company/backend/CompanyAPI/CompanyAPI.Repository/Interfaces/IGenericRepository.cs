using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyAPI.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        void DeleteAsync(T entity);
        Task SaveChangesAsync();
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        bool Exists(T entity);
    }
}
