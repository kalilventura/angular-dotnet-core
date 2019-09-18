using Api.Repository.Interface;
using API.Database;
using API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Implementation
{
    public class SellerRepository : ISellerRepository
    {
        private readonly ApiContext _context;

        public SellerRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync<T>(T entity) where T : class
        {
            try
            {
                await _context.AddAsync(entity);
            }
            catch (Exception error)
            {
                throw error;
            }
            return entity;
        }

        public async void DeleteAsync<T>(T entity) where T : class
        {
            try
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public async Task<T> UpdateAsync<T>(T entity) where T : class
        {
            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception error)
            {
                throw error;
            }
            return entity;
        }

        public async Task<IList<Seller>> GetAllSellersAsync()
        {
            return await _context.Sellers.ToListAsync<Seller>();
        }

        public async Task<IList<Seller>> GetBestSellerAsync()
        {
            return await _context.Sellers
                         .OrderBy(x => x.CommissionValue)
                         .Take(10)
                         .ToArrayAsync<Seller>();
        }

        public async Task<IList<Seller>> GetWorstSellersAsync()
        {
            return await _context.Sellers
                         .OrderByDescending(x => x.CommissionValue)
                         .Take(10)
                         .ToArrayAsync<Seller>();
        }

        public async Task<Seller> GetSellerByName(string name)
        {
            return await _context.Sellers
                              .Where(s => s.Name.Equals(name))
                              .FirstOrDefaultAsync<Seller>();
        }

        public async Task<Seller> GetSellerById(int id)
        {
            try
            {
                Seller seller = await _context.Sellers.FindAsync(id);
                return seller;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
