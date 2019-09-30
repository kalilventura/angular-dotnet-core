using System;
using System.Linq;
using System.Threading.Tasks;
using CompanyAPI.Domain.Models;
using CompanyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ValidateAntiForgeryToken]
    public class CompanyController : ControllerBase
    {
          ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var companies = await _companyService.GetAll();

                return StatusCode(StatusCodes.Status200OK, new { companies = companies });

            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = err.Message });
            }
        }

        [HttpGet("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                var company = await _companyService.GetById(id);

                return StatusCode(StatusCodes.Status200OK, new { company = company });

            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = err.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(Company company)
        {
            try
            {
                if (!ModelState.IsValid)
                    return StatusCode(StatusCodes.Status406NotAcceptable, 
                        new { message = ModelState.Values.SelectMany(e => e.Errors) });

                if (_companyService.Exists(company))
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Company Exists" });

                var result = await _companyService.Add(company);

                return StatusCode(StatusCodes.Status201Created,new { company = result });

            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = err.Message });
            }
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Put(Company company)
        {
            try
            {
                if (!ModelState.IsValid)
                    return StatusCode(StatusCodes.Status406NotAcceptable, 
                        new { message = ModelState.Values.SelectMany(e => e.Errors) });

                if (!_companyService.Exists(company))
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Company not exists" });

                var result = await _companyService.Alter(company);

                return StatusCode(StatusCodes.Status200OK, new { company = result });
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = err.Message });
            }
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Company company)
        {
            try
            {
                if (!ModelState.IsValid)
                    return StatusCode(StatusCodes.Status406NotAcceptable,
                        new { message = ModelState.Values.SelectMany(e => e.Errors) });

                if (!_companyService.Exists(company))
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Company not exists" });

                await _companyService.Delete(company);

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = err.Message });
            }
        }
    }
}