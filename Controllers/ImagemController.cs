using drakaysa.Data;
using drakaysa.Interfaces;
using drakaysa.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace drakaysa.Controllers
{
    [Route("api/[controller]")]
    public class ImagemController : ControllerBase//, IBaseController<Imagem>
    {
        private readonly DataContext _context;

        public ImagemController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Post([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Arquivo inválido!");

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            var imagem = new Imagem
            {
                Nome = file.FileName,
                Tipo = file.ContentType,
                ImagemBytes = memoryStream.ToArray()
            };

            _context.Imagens.Add(imagem);
            await _context.SaveChangesAsync();

            return Ok("Imagem salva com sucesso!");
        }

        [HttpGet]
        public IActionResult GetImagens()
        {
            var imagens = _context.Imagens;
            return Ok(imagens);
        }
    }
}
