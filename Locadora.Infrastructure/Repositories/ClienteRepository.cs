using System;
using System.Collections.Generic;
using System.Text;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Locadora.Infrastructure.Data;

namespace Locadora.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context) { _context = context; }

        public void Adicionar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void AdicionarEmMassa(IEnumerable<Cliente> clientes)
        {
            _context.Clientes.AddRange(clientes);
            _context.SaveChanges();
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _context.Clientes.ToList();
        }

        // Se ainda não tiver o ObterPorId:
        public Cliente ObterPorId(int id)
        {
            return _context.Clientes.Find(id)!;
        }

        public IEnumerable<Cliente> BuscarPorNome(string nome)
        {
            return _context.Clientes
                .Where(c => c.Nome.Contains(nome)) // É o equivalente ao LIKE '%nome%'
                .ToList();
        }

        public void Atualizar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public void Remover(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }
    }
}
