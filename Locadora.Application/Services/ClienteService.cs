using System;
using System.Collections.Generic;
using System.Text;
using Locadora.Application.DTOs;
using Locadora.Application.Interfaces;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;

namespace Locadora.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _clienteRepository.ObterTodos();
        }

        public Cliente Adicionar(ClienteRequestDTO clienteDto)
        {
            var novoCliente = new Cliente
            {
                Nome = clienteDto.Nome,
                Email = clienteDto.Email,
                Telefone = clienteDto.Telefone,
                Cpf = clienteDto.Cpf
            };

            _clienteRepository.Adicionar(novoCliente);
            return novoCliente;
        }

        public IEnumerable<Cliente> AdicionarEmMassa(IEnumerable<ClienteRequestDTO> clientesDto)
        {
            // Transforma cada DTO da lista em um Cliente real usando LINQ
            var clientes = clientesDto.Select(dto => new Cliente
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Telefone = dto.Telefone,
                Cpf = dto.Cpf
            }).ToList();

            // Manda a lista inteira para o Estoquista
            _clienteRepository.AdicionarEmMassa(clientes);

            return clientes;
        }

        public Cliente ObterPorId(int id)
        {
            return _clienteRepository.ObterPorId(id);
        }

        public IEnumerable<Cliente> BuscarPorNome(string nome)
        {
            if (string.IsNullOrEmpty(nome)) return new List<Cliente>();

            return _clienteRepository.BuscarPorNome(nome);
        }

        public bool Atualizar(int id, ClienteRequestDTO clienteDto)
        {
            // 1. Busca o cliente no banco
            var cliente = _clienteRepository.ObterPorId(id);

            // Se não achar, avisa que falhou (false)
            if (cliente == null) return false;

            // 2. Transfere os dados novos do DTO para o Cliente do banco
            cliente.Nome = clienteDto.Nome;
            cliente.Telefone = clienteDto.Telefone;
            cliente.Cpf = clienteDto.Cpf;
            cliente.Email = clienteDto.Email;
            // (Se você tiver Email, CPF ou outros campos, atualize-os aqui também: cliente.Email = clienteDto.Email, etc)

            // 3. Manda o repositório salvar
            _clienteRepository.Atualizar(cliente);
            return true; // Sucesso!
        }

        public bool Deletar(int id)
        {
            var cliente = _clienteRepository.ObterPorId(id);
            if (cliente == null) return false;

            _clienteRepository.Remover(cliente);
            return true;
        }
    }
}
