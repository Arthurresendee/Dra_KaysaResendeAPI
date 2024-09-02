using DRAKaysa.Interfaces;
using DRAKaysa.Services.Validators;
using DRAKaysaResende.Data;
using DRAKaysaResende.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DRAKaysa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DentistaController : ControllerBase, IBaseController<Dentista>
    {
        private readonly DataContext _context;
        private readonly DentistaValidator _validator;
        public DentistaController(DataContext context, DentistaValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dentista>>> GetAll()
        {
            try
            {
                var dentistas = await _context.Dentistas
                    .Include(x => x.Endereco).ToListAsync();

                if(dentistas == null || !dentistas.Any())
                {
                    return NotFound("Não foi encontrado nenhum dentista");
                }
                return Ok(dentistas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dentista>> GetById(int id)
        {
            try
            {
                var dentista = await _context.Dentistas
                    .Include(x => x.Endereco).FirstOrDefaultAsync(x => x.Id == id);

                if (dentista == null)
                {
                    return NotFound("Não foi encontrado nenhum dentista");
                }
                return Ok(dentista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Dentista>> Post([FromBody] Dentista dentista)
        {
            try
            {
                _validator.Validate(dentista);
                await _context.AddAsync(dentista);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetById", new { id = dentista.Id }, dentista);
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possível incluir um dentista");
            }
        }

        [HttpDelete]
        public Task<ActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public Task<ActionResult> Put(int id, Dentista item)
        {
            throw new NotImplementedException();
        }

        //[HttpPost]
    }
}
