using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirebaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialesController : ControllerBase
    {
        private readonly FirebaseService _firebaseService;

        public EditorialesController(FirebaseService firebaseService)
        {
            _firebaseService = firebaseService;
        }

        // GET: api/editoriales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editorial>>> GetEditoriales()
        {
            var editoriales = await _firebaseService.GetEditorialesAsync();
            return Ok(editoriales);
        }

        // GET: api/editoriales/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Editorial>> GetEditorial(string id)
        {
            var editorial = await _firebaseService.GetEditorialAsync(id);

            if (editorial == null)
            {
                return NotFound();
            }

            return Ok(editorial);
        }

        // POST: api/editoriales
        [HttpPost]
        public async Task<ActionResult<Editorial>> CreateEditorial(Editorial editorial)
        {
            await _firebaseService.CreateEditorialAsync(editorial);
            return CreatedAtAction(nameof(GetEditorial), new { id = editorial.Id }, editorial);
        }

        // PUT: api/editoriales/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEditorial(string id, Editorial editorial)
        {
            if (id != editorial.Id)
            {
                return BadRequest();
            }

            var existingEditorial = await _firebaseService.GetEditorialAsync(id);
            if (existingEditorial == null)
            {
                return NotFound();
            }

            await _firebaseService.UpdateEditorialAsync(id, editorial);
            return NoContent();
        }

        // DELETE: api/editoriales/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEditorial(string id)
        {
            var existingEditorial = await _firebaseService.GetEditorialAsync(id);
            if (existingEditorial == null)
            {
                return NotFound();
            }

            await _firebaseService.DeleteEditorialAsync(id);
            return NoContent();
        }
    }
}
