using drakaysa.Data;
using drakaysa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace drakaysa.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly DataContext _context;

        public LoginController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Logar([FromBody] LoginViewModel login)
        {
            try
            {
                var usuario = await _context.UsuariosdoSistema.FirstOrDefaultAsync(x => x.AcessoDeUsuario == login.Usuario && x.Senha == login.Senha);

                if (usuario == null)
                {
                    return Unauthorized(new { success = false, Message = "Usuário ou senha incorretos" });
                }

                return Ok(new { success = true, Message = "Login realizado com sucesso!" });

            }
            catch (Exception ex)
            {
                return BadRequest(new { sucess = false, Message = ex.Message });
            }
        }
    }
}