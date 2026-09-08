using System;
using System.Collections.Generic;
using System.Text;
using Locadora.Application.DTOs;
using Locadora.Domain.Models;

namespace Locadora.Application.Interfaces
{
    public interface IClienteService
    {
        IEnumerable<Cliente> ObterTodos();

        Cliente ObterPorId(int id);
        IEnumerable<Cliente> BuscarPorNome(string nome);

        Cliente Adicionar(ClienteRequestDTO clienteDto);
        IEnumerable<Cliente> AdicionarEmMassa(IEnumerable<ClienteRequestDTO> clientesDto);

        bool Atualizar(int id, ClienteRequestDTO clienteDto);
        bool Deletar(int id);
    }


}
