using Locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Locadora.Domain.Interfaces
{
    public interface ILocacaoRepository
    {
        void Adicionar(Locacao locacao);

        Locacao ObterPorId(int id);
        void Atualizar(Locacao locacao);

        IEnumerable<Locacao> ObterPendentes();

        IEnumerable<Locacao> ObterPorClienteId(int clienteId);
    }

    
    
}