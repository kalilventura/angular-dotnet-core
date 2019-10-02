using System;
using System.Collections.Generic;
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
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _address;
        private readonly IEmployeeService _employee;

        public AddressController(IAddressService address, IEmployeeService employee)
        {
            _address = address;
            _employee = employee;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _address.GetAll();

                return StatusCode(StatusCodes.Status200OK, new { address = result });
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = err.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Address address)
        {

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

                bool employeeExists = await _employee.Exists(address.EmployeeId);
                if (!employeeExists)
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Employee not exists." });

                var result = _address.Add(address);

                return StatusCode(StatusCodes.Status200OK, new { address = result });
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = err.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Address address)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

                bool employeeExists = await _employee.Exists(address.EmployeeId);
                if (!employeeExists)
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Employee not exists." });

                var result = await _address.Add(address);

                return StatusCode(StatusCodes.Status200OK, new { address = result });

            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = err.Message });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Address address)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

                bool employeeExists = await _employee.Exists(address.EmployeeId);
                if (!employeeExists)
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Employee not exists." });

                _address.Delete(address);

                return StatusCode(StatusCodes.Status200OK, new { message = "Address deleted successfully." });

            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = err.Message });
            }
        }

    }
}