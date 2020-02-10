using System.Threading.Tasks;
using CompanyAPI.Domain.Models;
using CompanyAPI.Repository.Queries;
using CompanyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyAPI.Controllers
{
    [Authorize]
    [ApiController]
    [ValidateAntiForgeryToken]
    [Route("api/[controller]")]
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

            return StatusCode(StatusCodes.Status200OK, new { companies });
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> Get(int id)
        {
            //var company = await _companyService.FindOne(x => x.Id == id);
            var company = await _companyService.FindOne(CompanyQueries.FindById(id));

            return StatusCode(StatusCodes.Status200OK, new { company });
        }

        [HttpGet]
        [Route("{companyName}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> Get(string companyName)
        {
            //var companies = await _companyService.Find(x => x.CompanyName.Contains(companyName));
            var companies = await _companyService.Find(CompanyQueries.FindByName(companyName));

            return StatusCode(StatusCodes.Status200OK, new { companies });
        }

        [HttpPost]
        [Authorize("Bearer")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] Company company)
        {
            //if (await _companyService.Exists(x => x.Id == company.Id))
            if (await _companyService.Exists(CompanyQueries.FindById(company.Id.Value)))
                return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Company Exists" });

            var result = await _companyService.Add(company);

            return StatusCode(StatusCodes.Status201Created, new { company = result });
        }

        [HttpPut]
        [Authorize("Bearer")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put([FromBody] Company company)
        {
            //bool exists = await _companyService.Exists(x => x.Id == company.Id);
            bool exists = await _companyService.Exists(CompanyQueries.FindById(company.Id.Value));
            if (!exists)
                return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Company not exists" });

            var alteredCompany = await _companyService.Alter(company);

            return StatusCode(StatusCodes.Status200OK, new { company = alteredCompany });
        }

        [HttpDelete]
        [Authorize("Bearer")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromBody] Company company)
        {
            //bool exists = await _companyService.Exists(x => x.Id == company.Id);
            bool exists = await _companyService.Exists(CompanyQueries.FindById(company.Id.Value));
            if (!exists)
                return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Company not exists" });

            _companyService.Delete(company);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}