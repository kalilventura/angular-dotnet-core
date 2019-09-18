using CompanyAPI.Database.Context;
using CompanyAPI.Domain.Models;
using CompanyAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAPI.Repository.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CompanyApiContext _context;

        public EmployeeRepository(CompanyApiContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddAsync(Employee entity)
        {
            try
            {
                await _context.Employees.AddAsync(entity);
                await SaveChangesAsync();
                return entity;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async void DeleteAsync(Employee entity)
        {
            try
            {
                _context.Employees.Remove(entity);
                await SaveChangesAsync();
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public bool Exists(Employee entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            try
            {
                return _context.Employees;

            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task<Employee> GetById(int id)
        {
            try
            {
                return _context.Employees.FirstOrDefault(x => x.Id.Equals(id));
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

        public async Task<Employee> UpdateAsync(Employee entity)
        {
            try
            {
                _context.Employees.Update(entity);
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
