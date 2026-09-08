using Microsoft.AspNetCore.Mvc;
using Locadora.Application.DTOs;
using Locadora.Application.Interfaces;

namespace LocadoraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly ILocacaoService _locacaoService;

        public LocacaoController(ILocacaoService locacaoService)
        {
            _locacaoService = locacaoService;
        }

        // POST: api/Locacao
        [HttpPost]
        public IActionResult PostLocacao([FromBody] LocacaoRequestDTO locacaoDto)
        {
            // O nome do método pode ser 'Adicionar' ou 'Alugar', dependendo de como você chamou na sua Interface ILocacaoService
            var locacaoCriada = _locacaoService.Adicionar(locacaoDto);

            return Created("", locacaoCriada);
        }

        // PUT: api/Locacao/devolver/5
        [HttpPut("devolver/{id}")]
        public IActionResult DevolverLocacao(int id)
        {
            try
            {
                var locacaoAtualizada = _locacaoService.Devolver(id);
                return Ok(locacaoAtualizada);
            }
            catch (Exception ex)
            {
                // Se cair nas nossas travas de segurança (ex: já devolvido), retorna erro 400
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Locacao/pendentes
        [HttpGet("pendentes")]
        public IActionResult GetPendentes()
        {
            var locacoesPendentes = _locacaoService.ObterPendentes();
            return Ok(locacoesPendentes);
        }

        // GET: api/Locacao/cliente/5
        [HttpGet("cliente/{clienteId}")]
        public IActionResult GetHistoricoPorCliente(int clienteId)
        {
            var historico = _locacaoService.ObterHistoricoPorCliente(clienteId);
            return Ok(historico);
        }
    }
}