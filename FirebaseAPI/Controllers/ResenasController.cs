using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirebaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResenasController : ControllerBase
    {
        private readonly FirebaseService _firebaseService;

        public ResenasController(FirebaseService firebaseService)
        {
            _firebaseService = firebaseService;
        }

        // GET: api/resenas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resena>>> GetResenas()
        {
            var resenas = await _firebaseService.GetResenasAsync();
            return Ok(resenas);
        }

        // GET: api/resenas/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Resena>> GetResena(string id)
        {
            var resena = await _firebaseService.GetResenaAsync(id);

            if (resena == null)
            {
                return NotFound();
            }

            return Ok(resena);
        }

        // POST: api/resenas
        [HttpPost]
        public async Task<ActionResult<Resena>> CreateResena(Resena resena)
        {
            await _firebaseService.CreateResenaAsync(resena);
            return CreatedAtAction(nameof(GetResena), new { id = resena.Id }, resena);
        }

        // PUT: api/resenas/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResena(string id, Resena resena)
        {
            if (id != resena.Id)
            {
                return BadRequest();
            }

            var existingResena = await _firebaseService.GetResenaAsync(id);
            if (existingResena == null)
            {
                return NotFound();
            }

            await _firebaseService.UpdateResenaAsync(id, resena);
            return NoContent();
        }

        // DELETE: api/resenas/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResena(string id)
        {
            var existingResena = await _firebaseService.GetResenaAsync(id);
            if (existingResena == null)
            {
                return NotFound();
            }

            await _firebaseService.DeleteResenaAsync(id);
            return NoContent();
        }
    }
}
