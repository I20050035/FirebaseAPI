using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirebaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly FirebaseService _firebaseService;

        public UsuariosController(FirebaseService firebaseService)
        {
            _firebaseService = firebaseService;
        }

        // GET: api/usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await _firebaseService.GetUsuariosAsync();
            return Ok(usuarios);
        }

        // GET: api/usuarios/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(string id)
        {
            var usuario = await _firebaseService.GetUsuarioAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // POST: api/usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuario(Usuario usuario)
        {
            await _firebaseService.CreateUsuarioAsync(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Uid }, usuario);
        }

        // PUT: api/usuarios/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(string id, Usuario usuario)
        {
            if (id != usuario.Uid)
            {
                return BadRequest();
            }

            var existingUsuario = await _firebaseService.GetUsuarioAsync(id);
            if (existingUsuario == null)
            {
                return NotFound();
            }

            await _firebaseService.UpdateUsuarioAsync(id, usuario);
            return NoContent();
        }

        // DELETE: api/usuarios/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(string id)
        {
            var existingUsuario = await _firebaseService.GetUsuarioAsync(id);
            if (existingUsuario == null)
            {
                return NotFound();
            }

            await _firebaseService.DeleteUsuarioAsync(id);
            return NoContent();
        }
    }
}
