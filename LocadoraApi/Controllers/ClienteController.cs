using Microsoft.AspNetCore.Mvc;
using Locadora.Application.DTOs;
using Locadora.Application.Interfaces;

namespace LocadoraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        // 1. O Garçom não fala mais com o banco (AppDbContext). Ele fala com o Chef (IClienteService).
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: api/Cliente - Buscar todos os Clientes
        [HttpGet]
        public IActionResult GetClientes()
        {
            var clientes = _clienteService.ObterTodos();
            return Ok(clientes);
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            var cliente = _clienteService.ObterPorId(id);
            if (cliente == null) return NotFound("Cliente não encontrado.");
            return Ok(cliente);
        }

        // GET: api/Cliente/buscar?nome=adolfo
        [HttpGet("buscar")]
        public IActionResult BuscarClientes([FromQuery] string nome)
        {
            var clientes = _clienteService.BuscarPorNome(nome);
            return Ok(clientes);
        }

        // POST: api/Cliente - Cadastrar um cliente
        [HttpPost]
        // 2. O SEGREDO AQUI: Recebemos o ClienteRequestDTO em vez do Cliente!
        public IActionResult PostCliente([FromBody] ClienteRequestDTO clienteDto)
        {
            // Mandamos a Bandeja para o Chef e recebemos o Prato Pronto (Cliente com ID)
            var clienteCriado = _clienteService.Adicionar(clienteDto);

            // Devolvemos o status 201 (Sucesso/Criado) e mostramos os dados do cliente salvo
            return Created("", clienteCriado);
        }

        // POST: api/Cliente/em-massa
        [HttpPost("em-massa")]
        public IActionResult PostClientesEmMassa([FromBody] IEnumerable<ClienteRequestDTO> clientesDto)
        {
            var clientesCriados = _clienteService.AdicionarEmMassa(clientesDto);
            return Ok(clientesCriados);
        }

        // ==========================================
        // 3. MÉTODOS DE ATUALIZAÇÃO (PUT)
        // ==========================================

        // PUT: api/Cliente/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClienteRequestDTO clienteDto)
        {
            var sucesso = _clienteService.Atualizar(id, clienteDto);

            if (!sucesso)
                return NotFound("Cliente não encontrado.");

            return NoContent(); // 204 No Content
        }

        // ==========================================
        // 4. MÉTODOS DE EXCLUSÃO (DELETE)
        // ==========================================

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sucesso = _clienteService.Deletar(id);

            if (!sucesso)
                return NotFound("Cliente não encontrado.");

            return NoContent(); // 204 No Content
        }
    }
}