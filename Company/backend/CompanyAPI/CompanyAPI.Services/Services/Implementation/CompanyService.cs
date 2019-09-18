using CompanyAPI.Domain.Models;
using CompanyAPI.Repository.Interfaces;
using CompanyAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyAPI.Services.Implementation
{
    public class CompanyService : ICompanyService
    {
        private ICompanyRepository _company;

        public CompanyService(ICompanyRepository company)
        {
            _company = company;
        }

        public async Task<Company> Add(Company entity)
        {
            try
            {
                var result = await _company.AddAsync(entity);
                return result;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task<Company> Alter(Company entity)
        {
            try
            {
                var result = await _company.UpdateAsync(entity);
                return result;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task Delete(Company entity)
        {
            try
            {
                _company.DeleteAsync(entity);
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
                return _company.Exists(entity);
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
                var result = await _company.GetAll();
                return result;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public Task<Company> GetById(int id)
        {
            try
            {
                var result = _company.GetById(id);
                return result;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
