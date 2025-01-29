using drakaysa.Data;
using drakaysa.Extensions;
using drakaysa.Interfaces;
using drakaysa.Models;
using drakaysa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace drakaysa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase, IBaseController<Card>
    {
        private readonly DataContext _context;

        public CardController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Card
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> GetAll()
        {
            try
            {
                var cards = await _context.Cards
                    .Include(c => c.Topico) // Inclui os tópicos relacionados
                    .OrderByDescending(c => c.Id)
                    .ToListAsync();

                if (cards == null || !cards.Any())
                {
                    return NotFound(new ResultViewModel<List<Card>>("Nenhum Card encontrado."));
                }

                return Ok(new ResultViewModel<List<Card>>(cards));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<List<Card>>("Erro interno no servidor."));
            }
        }

        // GET: api/Card/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> GetById(int id)
        {
            try
            {
                var card = await _context.Cards
                    .Include(c => c.Topico)
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (card == null)
                {
                    return NotFound(new ResultViewModel<Card>("Card não encontrado."));
                }

                return Ok(new ResultViewModel<Card>(card));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Card>("Erro interno no servidor."));
            }
        }

        // POST: api/Card
        [HttpPost]
        public async Task<ActionResult<Card>> Post([FromBody] Card card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel<Card>(ModelState.GetErrors()));
            }

            try
            {
                await _context.Cards.AddAsync(card);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetById", new { id = card.Id }, new ResultViewModel<Card>(card));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Card>("Erro interno no servidor."));
            }
        }

        // PUT: api/Card/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Card card)
        {
            var existingCard = await _context.Cards.FindAsync(id);
            if (existingCard == null)
            {
                return NotFound(new ResultViewModel<Card>("Card não encontrado."));
            }

            existingCard.Titulo = card.Titulo;
            existingCard.Texto = card.Texto;
            existingCard.TopicoId = card.TopicoId;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno no servidor.");
            }
        }

        // DELETE: api/Card/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var card = await _context.Cards.FindAsync(id);
            if (card == null)
            {
                return NotFound(new ResultViewModel<Card>("Card não encontrado."));
            }

            try
            {
                _context.Cards.Remove(card);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno no servidor.");
            }
        }
    }
}
