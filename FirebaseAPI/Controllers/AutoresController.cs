using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirebaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly FirebaseService _firebaseService;

        public AutoresController(FirebaseService firebaseService)
        {
            _firebaseService = firebaseService;
        }

        // GET: api/autores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutores()
        {
            var autores = await _firebaseService.GetAutoresAsync();
            return Ok(autores);
        }

        // GET: api/autores/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Autor>> GetAutor(string id)
        {
            var autor = await _firebaseService.GetAutorAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
            return Ok(autor);
        }

        // POST: api/autores
        [HttpPost]
        public async Task<ActionResult<Autor>> CreateAutor(Autor autor)
        {
            await _firebaseService.CreateAutorAsync(autor);
            return CreatedAtAction(nameof(GetAutor), new { id = autor.Id }, autor);
        }

        // PUT: api/autores/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAutor(string id, Autor autor)
        {
            if (id != autor.Id)
            {
                return BadRequest();
            }

            var existingAutor = await _firebaseService.GetAutorAsync(id);
            if (existingAutor == null)
            {
                return NotFound();
            }

            await _firebaseService.UpdateAutorAsync(id, autor);
            return NoContent();
        }

        // DELETE: api/autores/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor(string id)
        {
            var existingAutor = await _firebaseService.GetAutorAsync(id);
            if (existingAutor == null)
            {
                return NotFound();
            }

            await _firebaseService.DeleteAutorAsync(id);
            return NoContent();
        }
    }
}
