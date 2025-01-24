using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DRAKaysa.Data;
using DRAKaysa.Models;
using DRAKaysa.ViewModels;
using DRAKaysa.Extensions;
using DRAKaysa.Interfaces;

namespace DRAKaysa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicoController : ControllerBase, IBaseController<Topico>
    {
        private readonly DataContext _context;

        public TopicoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Topico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Topico>>> GetAll()
        {
            try
            {
                var topicos = await _context.Topicos
                    .Include(t => t.Cards)
                    .OrderByDescending(x => x.Id)
                    .ToListAsync();

                if (!topicos.Any())
                {
                    return NotFound(new ResultViewModel<List<Topico>>("Nenhum tópico foi encontrado."));
                }

                return Ok(new ResultViewModel<List<Topico>>(topicos));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<List<Topico>>("Falha interna no servidor."));
            }
        }

        // GET: api/Topico/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Topico>> GetById(int id)
        {
            try
            {
                var topico = await _context.Topicos
                    .Include(t => t.Cards)
                    .FirstOrDefaultAsync(t => t.Id == id);

                if (topico == null)
                {
                    return NotFound(new ResultViewModel<Topico>("Tópico não encontrado."));
                }

                return Ok(new ResultViewModel<Topico>(topico));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Topico>("Falha interna no servidor."));
            }
        }

        // POST: api/Topico
        [HttpPost]
        public async Task<ActionResult<Topico>> Post([FromBody] Topico topico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel<Topico>(ModelState.GetErrors()));
            }

            try
            {
                await _context.Topicos.AddAsync(topico);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetById", new { id = topico.Id }, topico);
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Topico>("Falha interna no servidor."));
            }
        }

        // PUT: api/Topico/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Topico topico)
        {
            var existingTopico = await _context.Topicos.FindAsync(id);

            if (existingTopico == null)
            {
                return NotFound(new ResultViewModel<Topico>("Tópico não encontrado."));
            }

            existingTopico.TituloTopico = topico.TituloTopico;

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

        // DELETE: api/Topico/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var topico = await _context.Topicos.FindAsync(id);

            if (topico == null)
            {
                return NotFound(new ResultViewModel<Topico>("Tópico não encontrado."));
            }

            try
            {
                _context.Topicos.Remove(topico);
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
