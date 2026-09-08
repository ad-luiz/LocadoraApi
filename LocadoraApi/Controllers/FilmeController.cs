using Locadora.Application.DTOs;
using Locadora.Application.Interfaces;
using Locadora.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _filmeService;

        
        public FilmeController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpGet]
        public IActionResult Get()
        {
           
            var filmes = _filmeService.ObterTodos();
            return Ok(filmes);
        }

        // GET: api/Filme/5
        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            var filme = _filmeService.ObterPorId(id);
            if (filme == null) return NotFound("Filme não encontrado.");
            return Ok(filme);
        }

        // GET: api/Filme/buscar?titulo=matrix&genero=acao
        [HttpGet("buscar")]
        public IActionResult BuscarFilmes([FromQuery] string? titulo, [FromQuery] string? genero)
        {
            var filmes = _filmeService.Buscar(titulo, genero);
            return Ok(filmes);
        }

        [HttpPost]
        public IActionResult Post([FromBody] FilmeRequestDTO filmeDto)
        {
            // Note que recebemos o DTO (sem ID) em vez da classe Filme inteira!
            var filmeSalvo = _filmeService.Adicionar(filmeDto);

            // Retorna status 201 (Created) e os dados do filme salvo
            return CreatedAtAction(nameof(Get), new { id = filmeSalvo.Id }, filmeSalvo);
        }

        // POST: api/Filme/em-massa
        [HttpPost("em-massa")]
        public IActionResult PostClientesEmMassa([FromBody] IEnumerable<FilmeRequestDTO> filmesDto)
        {
            var filmesCriados = _filmeService.AdicionarEmMassa(filmesDto);
            return Ok(filmesCriados);
        }
    }
}