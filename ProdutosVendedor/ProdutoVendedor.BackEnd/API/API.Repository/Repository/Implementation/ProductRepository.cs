using API.Database;
using API.Domain.Models;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiContext _context;

        public ProductRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync<T>(T entity) where T : class
        {
            try
            {
                await _context.AddAsync(entity);
                // await _context.SaveChangesAsync();
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

        public async Task<IList<Product>> GetAllProductsAsync()
        {
            try
            {
                return await _context.Products.ToListAsync();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                Product product = await _context.Products.FindAsync(id);
                return product;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
