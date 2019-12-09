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
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<IActionResult> Get()
        {
            var companies = await _companyService.GetAll();

            return StatusCode(StatusCodes.Status200OK, new { companies = companies });
        }

        [HttpGet]
        [Route("{id: int}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> Get(int id)
        {
            var company = await _companyService.GetById(id);

            return StatusCode(StatusCodes.Status200OK, new { company = company });
        }

        [HttpGet]
        [Route("{companyName: string}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> Get(string companyName)
        {
            var companies = await _companyService.GetByCompanyName(companyName);

            return StatusCode(StatusCodes.Status200OK, new { company = companies });
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<IActionResult> Post([FromBody] Company company)
        {
            if (await _companyService.Exists(company.Id))
                return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Company Exists" });

            var result = await _companyService.Add(company);

            return StatusCode(StatusCodes.Status201Created, new { company = result });
        }

        [HttpPut]
        [Authorize("Bearer")]
        public async Task<IActionResult> Put([FromBody] Company company)
        {
            bool exists = await _companyService.Exists(company.Id);
            if (!exists)
                return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Company not exists" });

            var result = await _companyService.Alter(company);

            return StatusCode(StatusCodes.Status200OK, new { company = result });
        }

        [HttpDelete]
        [Authorize("Bearer")]
        public async Task<IActionResult> Delete([FromBody] Company company)
        {
            bool exists = await _companyService.Exists(company.Id);
            if (!exists)
                return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Company not exists" });

            _companyService.Delete(company);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}