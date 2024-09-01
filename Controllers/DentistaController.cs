using DRAKaysaResende.Data;
using DRAKaysaResende.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DRAKaysa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DentistaController : ControllerBase
    {
        private readonly DataContext _Context;
        public DentistaController(DataContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dentista>>> GetAll()
        {
            try
            {
                var dentistas = await _Context.Dentistas
                    .Include(x => x.Endereco).ToListAsync();

                if(dentistas == null || !dentistas.Any())
                {
                    return NotFound("Não foi encontrado nenhum endereço");
                }
                return Ok(dentistas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPost]
    }
}
