using CompanyAPI.Domain.Models;
using CompanyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Get()
        {
            try
            {
                var employees = await employeeService.GetAll();

                return Ok(employees.ToList());

            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var employee = await employeeService.GetById(id);

                return Ok(employee);

            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            try
            {
                var result = await employeeService.Add(employee);

                return Ok(result);

            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Put([FromBody] Employee employee)
        {
            try
            {
                var result = await employeeService.Alter(employee);

                return Ok(result);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromBody] Employee employee)
        {
            try
            {
                await employeeService.Delete(employee);

                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}