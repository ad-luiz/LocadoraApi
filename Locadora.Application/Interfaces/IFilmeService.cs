// Importações padrão do sistema (algumas não estão sendo usadas aqui, mas vêm por padrão).
using System;
using System.Collections.Generic;
using System.Text;

// Importamos a pasta onde estão as nossas "bandejas" (DTOs) para podermos usá-las aqui.
using Locadora.Application.DTOs;

// Importamos a pasta do nosso "Coração" (Domain), pois é lá que mora a classe real 'Filme'.
using Locadora.Domain.Models;

// O namespace indica que este arquivo mora na camada 'Application', dentro da pasta 'Interfaces'.
namespace Locadora.Application.Interfaces
{
    // 'public': A interface é pública para que a API (o Garçom) e o Service (o Chef) possam enxergá-la.
    // 'interface': É um CONTRATO (ou um Cardápio). 
    // A interface NÃO tem código de lógica dentro dela. Ela apenas diz O QUE deve ser feito, mas nunca COMO deve ser feito.
    // A letra 'I' maiúscula no começo do nome (IFilmeService) é uma regra universal do C# para identificar rapidamente que isso é uma Interface.
    public interface IFilmeService
    {
        // Contrato 1: ObterTodos
        // 'IEnumerable<Filme>': Significa que este método vai devolver uma lista (uma coleção) da classe original 'Filme'. O IEnumerable é ótimo porque é uma lista leve e apenas de leitura.
        // O método não tem "corpo" (não tem chaves {}). Ele termina no ponto e vírgula, firmando o contrato: "Quem assinar esta interface, é OBRIGADO a criar um método que retorne uma lista de filmes".
        IEnumerable<Filme> ObterTodos();

        // Contrato 2: Adicionar
        // Aqui vemos a mágica da segurança acontecendo:
        // Ele RECEBE como parâmetro o 'FilmeRequestDTO' (a versão segura que veio da internet, sem o ID).
        // Ele DEVOLVE (retorna) a classe 'Filme' inteira (pois, após salvar, queremos devolver a resposta completa, mostrando qual ID o banco de dados gerou para aquele filme).
        Filme Adicionar(FilmeRequestDTO filmeDto);
        IEnumerable<Filme> AdicionarEmMassa(IEnumerable<FilmeRequestDTO> filmesDto);

        IEnumerable<Filme> Buscar(string? titulo, string? genero);
        Filme ObterPorId(int id); // Garantindo que você tenha o ObterPorId no contrato
    }
}