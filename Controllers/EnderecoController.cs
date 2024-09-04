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
using Microsoft.IdentityModel.Tokens;
using DRAKaysa.Services;
using DRAKaysa.Services.Validators;
using DRAKaysa.Interfaces;
using DRAKaysa.Extensions;

namespace DRAKaysa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase, IBaseController<Endereco>
    {
        private readonly DataContext _context;
        private readonly EnderecoValidator _validator;

        public EnderecoController(DataContext context, EnderecoValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        // GET: api/Endereco
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Endereco>>> GetAll()
        {
            try
            {
                var enderecos = await _context.Enderecos.ToListAsync();
                if (enderecos.IsNullOrEmpty())
                {
                    return NotFound("Não foi encontrado nenhum Endereço");
                }
                return Ok(new ResultViewModel<List<Endereco>>(enderecos));
            }
            catch (Exception ex)
            {
                return StatusCode(500,new ResultViewModel<List<Endereco>>("Falha interna"));
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
                    return NotFound(new ResultViewModel<Endereco>("Endereço não encontrado"));
                }

                return Ok(new ResultViewModel<Endereco>(endereco));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Endereco>("Falha interna no servidor"));
            }
        }

        //api/Endereco
        [HttpPost]
        public async Task<ActionResult<Endereco>> Post([FromBody] Endereco endereco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel<Endereco>(ModelState.GetErrors()));
            }

            try
            {
                endereco.GerarDescricao();
                await _context.Enderecos.AddAsync(endereco);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetById", new { id = endereco.Id }, endereco);

            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Endereco>("Falha interna no servidor"));
            }
        }

        //api/Endereco/id
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]Endereco endereco)
        {
            var end = await _context.Enderecos.FindAsync(id);
            if (end == null)
            {
                return NotFound("Endereço não encontrado.");
            }

            end.CEP = endereco.CEP;
            end.Rua = endereco.Rua;
            end.Bairro = endereco.Bairro;
            end.Cidade = endereco.Cidade;
            end.Estado = endereco.Estado;

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

        //api/Endereco/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }

            try
            {
                _context.Enderecos.Remove(endereco);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        [HttpGet("cep/{CEP}")]
        public async Task<ActionResult<IEnumerable<Endereco>>> GetByCEP(string cep)
        {
            try
            {
                var endereco = await _context.Enderecos
                                    .Where(x => x.CEP == cep)
                                    .ToListAsync();

                if (endereco == null || !endereco.Any())
                {
                    return NotFound("Usuario não encontrado");
                }
                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet("options/select")]
        //public async Task<ActionResult<IEnumerable<EnderecoSelectOptionViewModel>>> GetEnderecoOptions()
        //{
        //    try
        //    {
        //        var enderecos = await _context.Enderecos.ToListAsync();
        //        if (enderecos == null || !enderecos.Any())
        //        {
        //            return NotFound("Não foi encontrado nenhum Endereço");
        //        }

        //        var response = enderecos.Select(endereco => new EnderecoSelectOptionViewModel
        //        {
        //            CEP = endereco.CEP,
        //            Rua = endereco.Rua,
        //            Numero = endereco.Numero,
        //            Bairro = endereco.Bairro,
        //            Cidade = endereco.Cidade,
        //            Estado = endereco.Estado,
        //            Descricao = $"{endereco.Rua}, {endereco.Numero}, {endereco.Bairro} - {endereco.Cidade} / {endereco.Estado}"
        //        }).ToList();

        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
