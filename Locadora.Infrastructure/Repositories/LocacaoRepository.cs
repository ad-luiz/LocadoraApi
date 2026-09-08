using System;
using System.Collections.Generic;
using System.Text;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Locadora.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infrastructure.Repositories
{
    public class LocacaoRepository : ILocacaoRepository
    {
        private readonly AppDbContext _context;

        public LocacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Locacao locacao)
        {
            _context.Locacoes.Add(locacao);
            _context.SaveChanges();
        }

        public Locacao ObterPorId(int id)
        {
            return _context.Locacoes.Find(id)!;
        }

        public void Atualizar(Locacao locacao)
        {
            _context.Locacoes.Update(locacao);
            _context.SaveChanges();
        }

        public IEnumerable<Locacao> ObterPendentes()
        {
            return _context.Locacoes
                // O Include traz a "ficha completa" do Cliente e do Filme!
                .Include(l => l.Cliente)
                .Include(l => l.Filme)
                // O Where é o nosso filtro: traz apenas os não devolvidos
                .Where(l => l.Devolvido == false)               
                .ToList();
        }

        public IEnumerable<Locacao> ObterPorClienteId(int clienteId)
        {
            return _context.Locacoes
                .Include(l => l.Filme) // Traz os dados do filme junto
                .Where(l => l.ClienteId == clienteId) // Filtra apenas pelo cliente escolhido
                .ToList();
        }
    }
}
