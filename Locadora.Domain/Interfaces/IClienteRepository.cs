using System;
using System.Collections.Generic;
using System.Text;
using Locadora.Domain.Models;

namespace Locadora.Domain.Interfaces
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> ObterTodos();

        Cliente ObterPorId(int id); 
        IEnumerable<Cliente> BuscarPorNome(string nome);

        void Adicionar(Cliente cliente);
        void AdicionarEmMassa(IEnumerable<Cliente> clientes);

        void Atualizar(Cliente cliente);
        void Remover(Cliente cliente);
    }
}
