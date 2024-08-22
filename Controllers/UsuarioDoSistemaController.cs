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
        public async Task<ActionResult<IEnumerable<UsuarioDoSistema>>> GetAll()
        {
            try
            {
                var usuarios = _context.UsariosdoSistema.ToList();
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
        public async Task<ActionResult<Endereco>> GetById(int id)
        {
            try
            {
                var usuario = await _context.UsariosdoSistema.FirstOrDefaultAsync(x => x.Id == id);
                if (usuario == null)
                {
                    return NotFound("nenhum endereco encontrado");
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
