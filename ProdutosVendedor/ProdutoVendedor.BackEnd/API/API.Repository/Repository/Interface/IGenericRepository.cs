using System.Threading.Tasks;

namespace API.Repository.Interface
{
    public interface IGenericRepository
    {
        Task<T> AddAsync<T>(T entity) where T : class;
        Task<T> UpdateAsync<T>(T entity) where T : class;
        void DeleteAsync<T>(T entity) where T : class;
        Task SaveChangesAsync();
    }
}
