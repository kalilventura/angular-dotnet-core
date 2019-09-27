using System;
using System.Linq;
using System.Threading.Tasks;
using CompanyAPI.Domain.Models;
using CompanyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Get()
        {
            try
            {
                var companies = await companyService.GetAll();

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
                var company = await companyService.GetById(id);

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

                if (companyService.Exists(company))
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Company Exists" });

                var result = await companyService.Add(company);

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

                if (!companyService.Exists(company))
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Company not exists" });

                var result = await companyService.Alter(company);

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

                if (!companyService.Exists(company))
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Company not exists" });

                await companyService.Delete(company);

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = err.Message });
            }
        }
    }
}