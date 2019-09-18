using CompanyAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyAPI.Services.Interfaces
{
    public interface IBaseInterface<T> where T : Entity
    {
        Task<T> Add(T entity);
        Task Delete(T entity);
        Task<T> Alter(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        bool Exists(T entity);
    }
}
