using CompanyAPI.Database.Context;
using CompanyAPI.Domain.Models;
using CompanyAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyAPI.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        protected readonly CompanyApiContext _context;
        private DbSet<T> _dataset;

        public GenericRepository(CompanyApiContext context)
        {
            _context = context;
            _dataset = context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await _dataset.AddAsync(entity);
                await SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void DeleteAsync(T entity)
        {
            try
            {
                _context.Remove(entity);
                await SaveChangesAsync();
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task<bool> Exists(int? id)
        {
            return await _dataset.AnyAsync(b => b.Id.Equals(id));
        }

        public async Task<IList<T>> FindAll()
        {
            return await _dataset.ToListAsync();
        }

        public async Task<T> GetById(int? id)
        {
            return await _dataset.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        private async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                _context.Update(entity);
                await SaveChangesAsync();
                return entity;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
