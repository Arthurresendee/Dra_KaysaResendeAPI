using DRAKaysa.Models;
using DRAKaysa.ViewModels;
using DRAKaysaResende.Data;
using DRAKaysaResende.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Drawing.Text;

namespace DRAKaysa.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioDoSistemaController : Controller
    {
        private readonly DataContext _context;

        public UsuarioDoSistemaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var usuarios = _context.UsuariosdoSistema.ToList();
                if (usuarios.IsNullOrEmpty())
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
        public async Task<ActionResult> GetById(int id)
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
        public async Task<ActionResult> Post([FromBody] UsuarioDoSistema usuario)
        {
            try
            {
                await _context.UsuariosdoSistema.AddAsync(usuario);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetById", new { id = usuario.Id }, usuario);

            }
            catch (Exception ex)
            {
                return BadRequest("algo deu errado");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]UsuarioDoSistema usuario)
        {
            var user = await _context.UsuariosdoSistema.FindAsync(id);
            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

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
        public async Task<IActionResult> Delete(int id)
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
    }
}
