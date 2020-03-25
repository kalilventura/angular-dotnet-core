using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.WebApi.Data;

namespace ProAgil.WebApi.Controllers {

    [Route ("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {
        public readonly DataContext _context;
        public ValuesController (DataContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get () {
            try {
                var results = await _context.Eventos.ToListAsync ();
                return StatusCode (StatusCodes.Status200OK, results);
            } catch (System.Exception) {
                return StatusCode (StatusCodes.Status500InternalServerError, new { message = "Failed." });
            }
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> Get (int id) {
            try {
                var results = await _context.Eventos.FirstOrDefaultAsync (x => x.EventoId.Equals (id));
                return StatusCode (StatusCodes.Status200OK, results);
            } catch (System.Exception) {
                return StatusCode (StatusCodes.Status500InternalServerError, new { message = "Failed." });
            }
        }

    }
}