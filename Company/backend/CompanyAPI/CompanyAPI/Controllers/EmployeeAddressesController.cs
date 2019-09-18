using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompanyAPI.Database.Context;
using CompanyAPI.Domain.Models;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAddressesController : ControllerBase
    {
        private readonly CompanyApiContext _context;

        public EmployeeAddressesController(CompanyApiContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeAddresses>>> GetEmployeeAddresses()
        {
            return await _context.EmployeeAddresses.ToListAsync();
        }

        // GET: api/EmployeeAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeAddresses>> GetEmployeeAddresses(int id)
        {
            var employeeAddresses = await _context.EmployeeAddresses.FindAsync(id);

            if (employeeAddresses == null)
            {
                return NotFound();
            }

            return employeeAddresses;
        }

        // PUT: api/EmployeeAddresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeAddresses(int id, EmployeeAddresses employeeAddresses)
        {
            if (id != employeeAddresses.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employeeAddresses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeAddressesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmployeeAddresses
        [HttpPost]
        public async Task<ActionResult<EmployeeAddresses>> PostEmployeeAddresses(EmployeeAddresses employeeAddresses)
        {
            _context.EmployeeAddresses.Add(employeeAddresses);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeAddressesExists(employeeAddresses.EmployeeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployeeAddresses", new { id = employeeAddresses.EmployeeId }, employeeAddresses);
        }

        // DELETE: api/EmployeeAddresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeAddresses>> DeleteEmployeeAddresses(int id)
        {
            var employeeAddresses = await _context.EmployeeAddresses.FindAsync(id);
            if (employeeAddresses == null)
            {
                return NotFound();
            }

            _context.EmployeeAddresses.Remove(employeeAddresses);
            await _context.SaveChangesAsync();

            return employeeAddresses;
        }

        private bool EmployeeAddressesExists(int id)
        {
            return _context.EmployeeAddresses.Any(e => e.EmployeeId == id);
        }
    }
}
