using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirebaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly FirebaseService _firebaseService;

        public LibrosController(FirebaseService firebaseService)
        {
            _firebaseService = firebaseService;
        }

        // GET: api/libros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibros()
        {
            var libros = await _firebaseService.GetLibrosAsync();
            return Ok(libros);
        }

        // GET: api/libros/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Libro>> GetLibro(string id)
        {
            var libro = await _firebaseService.GetLibroAsync(id);

            if (libro == null)
            {
                return NotFound();
            }

            return Ok(libro);
        }

        // POST: api/libros
        [HttpPost]
        public async Task<ActionResult<Libro>> CreateLibro(Libro libro)
        {
            await _firebaseService.CreateLibroAsync(libro);
            return CreatedAtAction(nameof(GetLibro), new { id = libro.Id }, libro);
        }

        // PUT: api/libros/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLibro(string id, Libro libro)
        {
            if (id != libro.Id)
            {
                return BadRequest();
            }

            var existingLibro = await _firebaseService.GetLibroAsync(id);
            if (existingLibro == null)
            {
                return NotFound();
            }

            await _firebaseService.UpdateLibroAsync(id, libro);
            return NoContent();
        }

        // DELETE: api/libros/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibro(string id)
        {
            var existingLibro = await _firebaseService.GetLibroAsync(id);
            if (existingLibro == null)
            {
                return NotFound();
            }

            await _firebaseService.DeleteLibroAsync(id);
            return NoContent();
        }
    }
}
