using CompanyAPI.Domain.Models;
using CompanyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var employees = await _employeeService.GetAll();

                return StatusCode(StatusCodes.Status200OK, new { employees = employees.ToList() });

            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = err.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var employee = await _employeeService.GetById(id);

                return StatusCode(StatusCodes.Status200OK, new { employee = employee });

            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = err.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

                var result = await _employeeService.Add(employee);

                return StatusCode(StatusCodes.Status200OK, new { employee = result });

            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = err.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

                var alteredEmployee = await _employeeService.Alter(employee);

                return StatusCode(StatusCodes.Status200OK, new { employee = alteredEmployee });
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = err.Message });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

                _employeeService.Delete(employee);

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = err.Message });
            }
        }
    }
}