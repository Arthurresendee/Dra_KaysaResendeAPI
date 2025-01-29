using drakaysa.Data;
using drakaysa.Extensions;
using drakaysa.Interfaces;
using drakaysa.Models;
using drakaysa.Services.Validators;
using drakaysa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace drakaysa.Controllers
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
                    .Include(x => x.Endereco)
                    .OrderByDescending(x => x.Id)
                    .ToListAsync();

                if (dentistas == null || !dentistas.Any())
                {
                    return NotFound(new ResultViewModel<List<Dentista>>("Não foi encontrado nenhum dentista"));
                }
                return Ok(new ResultViewModel<List<Dentista>>(dentistas));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultViewModel<List<Dentista>>("Falha interna no Servidor - NO80i1aTZ0WmiNPuws3lwA,"));
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
                    return NotFound(new ResultViewModel<Dentista>("Não foi encontrado nenhum dentista - Icgi5_Bo206_xUFjQuNToA,"));
                }
                return Ok(new ResultViewModel<Dentista>(dentista));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultViewModel<Dentista>("Falha interna no servidor"));
            }
        }

        [HttpPost]
        public async Task<ActionResult<Dentista>> Post([FromBody] Dentista dentista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel<Dentista>(ModelState.GetErrors()));
            }

            try
            {
                _validator.Validate(dentista);
                await _context.AddAsync(dentista);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetById", new { id = dentista.Id }, dentista);
            }
            catch (Exception ex)
            {
                return StatusCode(300, new ResultViewModel<List<Dentista>>("Falha interna no servidor - Icgi5_Bo206_xUFjQuNToA,"));
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

        [HttpGet("byname/{nome}")]
        public async Task<ActionResult<IEnumerable<Dentista>>> GetByName(string nome)
        {
            try
            {
                var dentistas = await _context.Dentistas
                                    .Where(x => x.Nome.Contains(nome))
                                    .OrderByDescending(x => x.Id)
                                    .ToListAsync();

                if (dentistas == null || !dentistas.Any())
                {
                    return NotFound(new ResultViewModel<Dentista>("Endereço não encontrado com esse nome"));
                }
                return Ok(new ResultViewModel<List<Dentista>>(dentistas));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
