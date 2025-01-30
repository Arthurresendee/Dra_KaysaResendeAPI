using drakaysa.Data;
using drakaysa.Interfaces;
using drakaysa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace drakaysa.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioDoSistemaController : Controller, IBaseController<UsuarioDoSistema>
    {
        private readonly DataContext _context;

        public UsuarioDoSistemaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDoSistema>>> GetAll()
        {
            try
            {
                var usuarios = await _context.UsuariosdoSistema.ToListAsync();
                if (!usuarios.Any())
                {
                    return NotFound("Não foi encontrado nenhum usuário");
                }
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDoSistema>> GetById(int id)
        {
            try
            {
                var usuario = await _context.UsuariosdoSistema.FirstOrDefaultAsync(x => x.Id == id);
                if (usuario == null)
                {
                    return NotFound("Usuario não encontrado");
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDoSistema>> Post([FromBody] UsuarioDoSistema usuario)
        {
            try
            {
                await _context.UsuariosdoSistema.AddAsync(usuario);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetById", new { id = usuario.Id }, usuario);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UsuarioDoSistema usuario)
        {
            var user = await _context.UsuariosdoSistema.FindAsync(id);
            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            user.TipoDeUsuario = usuario.TipoDeUsuario;
            user.AcessoDeUsuario = usuario.AcessoDeUsuario;
            user.Senha = usuario.Senha;
            user.NomeCompleto = usuario.NomeCompleto;
            user.TipoDeSexo = usuario.TipoDeSexo;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var user = await _context.UsuariosdoSistema.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            try
            {
                _context.UsuariosdoSistema.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        [HttpGet("user/{user}")]
        public async Task<ActionResult> GetByUser(string user)
        {
            try
            {
                var usuario = await _context.UsuariosdoSistema.FirstOrDefaultAsync(x => x.AcessoDeUsuario == user);
                if (usuario == null)
                {
                    return NotFound("Usuario não encontrado");
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
