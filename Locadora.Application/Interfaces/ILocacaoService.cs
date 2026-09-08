using Locadora.Application.DTOs;
using Locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Locadora.Application.Interfaces
{
    public interface ILocacaoService
    {
        Locacao Adicionar(LocacaoRequestDTO locacaoDto);

        Locacao Devolver(int locacaoId);

        IEnumerable<Locacao> ObterPendentes();

        IEnumerable<Locacao> ObterHistoricoPorCliente(int clienteId);
    }


}
