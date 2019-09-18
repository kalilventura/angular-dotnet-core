using API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    public interface IProductRepository : IGenericRepository
    {
        Task<IList<Product>> GetAllProductsAsync();
        Task<Product> GetProductById(int id);
    }
}
