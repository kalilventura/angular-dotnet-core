using CompanyAPI.Database.Context;
using CompanyAPI.Domain.Models;
using CompanyAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CompanyAPI.Repository.Implementation
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CompanyApiContext _context;

        public CompanyRepository(CompanyApiContext context)
        {
            _context = context;
        }
        public async Task<Company> AddAsync(Company entity)
        {
            try
            {
                await _context.Companies.AddAsync(entity);
                await SaveChangesAsync();
                return entity;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async void DeleteAsync(Company entity)
        {
            try
            {
                _context.Companies.Remove(entity);
                await SaveChangesAsync();
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public bool Exists(Company entity)
        {
            try
            {
                return _context.Companies.Any(x => x.CompanyName.Equals(entity.CompanyName));
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            try
            {
                return _context.Companies;
                
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task<Company> GetById(int id)
        {
            try
            {
                return _context.Companies.FirstOrDefault(x => x.Id.Equals(id));
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Company> UpdateAsync(Company entity)
        {
            try
            {
                _context.Companies.Update(entity);
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
