using CompanyAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyAPI.Services.Interfaces
{
    public interface IBaseService<T> where T : Entity
    {
        Task<T> Add(T entity);
        Task Delete(T entity);
        Task<T> Alter(T entity);
        Task<IList<T>> GetAll();
        Task<T> GetById(int id);
        Task<bool> Exists(int id);
    }
}
