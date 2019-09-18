using API.Domain.Models;
using API.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Repository.Interface
{
    public interface ISellerRepository : IGenericRepository
    {
        Task<IList<Seller>> GetAllSellersAsync();
        Task<IList<Seller>> GetBestSellerAsync();
        Task<IList<Seller>> GetWorstSellersAsync();
        Task<Seller> GetSellerByName(string name);
        Task<Seller> GetSellerById(int id);
    }
}
