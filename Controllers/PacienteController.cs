using DRAKaysa.Extensions;
using DRAKaysa.Interfaces;
using DRAKaysa.Services.Validators;
using DRAKaysa.ViewModels;
using DRAKaysa.Data;
using DRAKaysa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DRAKaysa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase, IBaseController<Paciente>
    {
        private readonly DataContext _context;
        private readonly PacienteValidator _validator;
        public PacienteController(DataContext context, PacienteValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetAll()
        {
            try
            {
                var pacientes = await _context.Pacientes
                    .Include(x => x.Dentista)
                    .Include(x => x.Endereco)
                    .OrderByDescending(x => x.Id)
                    .ToListAsync();

                if(pacientes == null || !pacientes.Any())
                {
                    return NotFound(new ResultViewModel<List<Paciente>>("Não foi encontrado nenhum paciente"));
                }
                return Ok(new ResultViewModel<List<Paciente>>(pacientes));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultViewModel<List<Paciente>>("Falha interna no Servidor - NO80i1aTZ0WmiNPuws3lwA,"));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetById(int id)
        {
            try
            {
                var paciente = await _context.Pacientes
                    .Include(x => x.Endereco)
                    .Include(x => x.Dentista)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (paciente == null)
                {
                    return NotFound(new ResultViewModel<Paciente>("Não foi encontrado nenhum paciente - Icgi5_Bo206_xUFjQuNToA,"));
                }
                return Ok(new ResultViewModel<Paciente>(paciente));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultViewModel<Paciente>("Falha interna no servidor"));
            }
        }

        [HttpPost]
        public async Task<ActionResult<Paciente>> Post([FromBody] Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel<Paciente>(ModelState.GetErrors()));
            }

            try
            {
                _validator.Validate(paciente);
                await _context.AddAsync(paciente);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetById", new { id = paciente.Id }, paciente);
            }
            catch (Exception ex)
            {
                return StatusCode(300,new ResultViewModel<List<Paciente>>("Falha interna no servidor - Icgi5_Bo206_xUFjQuNToA,"));
            }
        }

        [HttpDelete]
        public Task<ActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> Put(int id, Paciente item)
        {
            throw new NotImplementedException();
        }


        [HttpGet("byname/{nome}")]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetByName(string nome)
        {
            try
            {
                var pacientes = await _context.Pacientes
                                    .Where(x => x.Nome.Contains(nome))
                                    .OrderByDescending(x => x.Id)
                                    .ToListAsync();

                if (pacientes == null || !pacientes.Any())
                {
                    return NotFound(new ResultViewModel<Paciente>("Paciente não encontrado com esse nome"));
                }
                return Ok(new ResultViewModel<List<Paciente>>(pacientes));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
