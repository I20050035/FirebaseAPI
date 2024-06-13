using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirebaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly FirebaseService _firebaseService;

        public CategoriasController(FirebaseService firebaseService)
        {
            _firebaseService = firebaseService;
        }

        // GET: api/categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            var categorias = await _firebaseService.GetCategoriasAsync();
            return Ok(categorias);
        }

        // GET: api/categorias/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(string id)
        {
            var categoria = await _firebaseService.GetCategoriaAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        // POST: api/categorias
        [HttpPost]
        public async Task<ActionResult<Categoria>> CreateCategoria(Categoria categoria)
        {
            await _firebaseService.CreateCategoriaAsync(categoria);
            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.Id }, categoria);
        }

        // PUT: api/categorias/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoria(string id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }

            var existingCategoria = await _firebaseService.GetCategoriaAsync(id);
            if (existingCategoria == null)
            {
                return NotFound();
            }

            await _firebaseService.UpdateCategoriaAsync(id, categoria);
            return NoContent();
        }

        // DELETE: api/categorias/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(string id)
        {
            var existingCategoria = await _firebaseService.GetCategoriaAsync(id);
            if (existingCategoria == null)
            {
                return NotFound();
            }

            await _firebaseService.DeleteCategoriaAsync(id);
            return NoContent();
        }
    }
}
