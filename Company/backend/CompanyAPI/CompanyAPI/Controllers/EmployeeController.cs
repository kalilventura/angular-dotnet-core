using CompanyAPI.Domain.Models;
using CompanyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IAddressService _addressService;
        private readonly IEmployeeAddressService _employeeAddressService;

        public EmployeeController(
            IEmployeeService employeeService,
            IAddressService addressService,
            IEmployeeAddressService employeeAddressService)
        {
            _employeeService = employeeService;
            _addressService = addressService;
            _employeeAddressService = employeeAddressService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _employeeService.GetAll();

            return StatusCode(StatusCodes.Status200OK, new { employees = employees.ToList() });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            bool employeeExists = await _employeeService.Exists(id);
            if (!employeeExists)
                return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Employee not exists." });

            var employee = await _employeeService.GetById(id);

            return StatusCode(StatusCodes.Status200OK, new { selectedEmployee = employee });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            var result = await _employeeService.Add(employee);

            return StatusCode(StatusCodes.Status200OK, new { employee = result });
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Employee employee)
        {
            bool employeeExists = await _employeeService.Exists(employee.Id);
            if (!employeeExists)
                return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Employee not exists." });

            var alteredEmployee = await _employeeService.Alter(employee);

            return StatusCode(StatusCodes.Status200OK, new { employee = alteredEmployee });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Employee employee)
        {
            _employeeService.Delete(employee);

            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpPost]
        [Route("addAddress")]
        public async Task<IActionResult> AddAddress([FromBody] Address address)
        {
            bool employeeExists = await _employeeService.Exists(address.EmployeeId);
            if (!employeeExists)
                return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Employee not exists." });

            Address newAddress = await _addressService.Add(address);

            await _employeeAddressService.Add(new EmployeeAddress(newAddress));

            return StatusCode(StatusCodes.Status200OK, new { message = "Add" });
        }
    }
}