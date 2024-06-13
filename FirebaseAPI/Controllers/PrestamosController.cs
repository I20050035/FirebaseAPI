using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirebaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamosController : ControllerBase
    {
        private readonly FirebaseService _firebaseService;

        public PrestamosController(FirebaseService firebaseService)
        {
            _firebaseService = firebaseService;
        }

        // GET: api/prestamos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prestamo>>> GetPrestamos()
        {
            var prestamos = await _firebaseService.GetPrestamosAsync();
            return Ok(prestamos);
        }

        // GET: api/prestamos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Prestamo>> GetPrestamo(string id)
        {
            var prestamo = await _firebaseService.GetPrestamoAsync(id);

            if (prestamo == null)
            {
                return NotFound();
            }

            return Ok(prestamo);
        }

        // POST: api/prestamos
        [HttpPost]
        public async Task<ActionResult<Prestamo>> CreatePrestamo(Prestamo prestamo)
        {
            await _firebaseService.CreatePrestamoAsync(prestamo);
            return CreatedAtAction(nameof(GetPrestamo), new { id = prestamo.Id }, prestamo);
        }

        // PUT: api/prestamos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrestamo(string id, Prestamo prestamo)
        {
            if (id != prestamo.Id)
            {
                return BadRequest();
            }

            var existingPrestamo = await _firebaseService.GetPrestamoAsync(id);
            if (existingPrestamo == null)
            {
                return NotFound();
            }

            await _firebaseService.UpdatePrestamoAsync(id, prestamo);
            return NoContent();
        }

        // DELETE: api/prestamos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrestamo(string id)
        {
            var existingPrestamo = await _firebaseService.GetPrestamoAsync(id);
            if (existingPrestamo == null)
            {
                return NotFound();
            }

            await _firebaseService.DeletePrestamoAsync(id);
            return NoContent();
        }
    }
}
