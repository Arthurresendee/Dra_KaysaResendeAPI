using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DRAKaysaResende.Data;
using DRAKaysaResende.Models;
using DRAKaysa.ViewModels;

namespace DRAKaysa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly DataContext _context;

        public EnderecoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Endereco
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetAll()
        {
            try
            {
                var enderecos = _context.Enderecos.ToList();
                if (enderecos.Count() == 0)
                {
                    return NotFound(new ResultViewModel<List<Endereco>>("Nenhum endereco encontrado."));
                }
                return Ok(new ResultViewModel<List<Endereco>>(enderecos));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Endereco>($"{ex.Message}"));
            }
        }

        //api/Endereco/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Endereco>> GetById(int id)
        {
            try
            {
                var endereco = await _context.Enderecos.FirstOrDefaultAsync(x => x.Id == id);
                if (endereco == null)
                {
                    return NotFound(new ResultViewModel<List<Endereco>>("Nenhum endereco encontrado."));
                }

                return endereco;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        //api/Endereco/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEndereco(int id, Endereco endereco)
        {
            if (id != endereco.Id)
            {
                return BadRequest();
            }

            _context.Entry(endereco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //api/Endereco
        [HttpPost]
        public async Task<ActionResult<Endereco>> PostEndereco(Endereco endereco)
        {
            if (_context.Enderecos == null)
            {
                return Problem("Entity set 'DentiSysDataContext.Enderecos'  is null.");
            }
            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEndereco", new { id = endereco.Id }, endereco);
        }

        //api/Endereco/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEndereco(int id)
        {
            if (_context.Enderecos == null)
            {
                return NotFound();
            }
            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }

            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnderecoExists(int id)
        {
            return (_context.Enderecos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
