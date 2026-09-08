// Os 'usings' importam ferramentas prontas do C#. 
// É como dizer: "Vou precisar das caixas de ferramentas básicas do sistema".
// (Neste arquivo específico eles nem estão sendo usados, mas o Visual Studio os coloca por padrão).
using System;
using System.Collections.Generic;
using System.Text;

// O 'namespace' funciona como o "Endereço Completo" ou "CEP" desta classe.
// Ele organiza o código e diz que este arquivo mora no projeto 'Locadora.Application', dentro da pasta 'DTOs'.
namespace Locadora.Application.DTOs
{
    // 'public' significa que esta classe é pública e pode ser acessada por outros projetos (como a API).
    // 'class' define que estamos criando um molde de objeto.
    // 'DTO' (Data Transfer Object): Lembra da analogia do restaurante? Esta classe é apenas a "bandeja".
    // Ela serve SÓ para transportar dados da internet para o sistema, escondendo do usuário as informações do banco de dados (como o ID).
    public class FilmeRequestDTO
    {
        // Propriedade 1: Guarda o nome do filme.
        // 'string': Tipo de dado para textos.
        // '{ get; set; }': Permite que o programa leia o valor (get) ou altere o valor (set).
        // '= string.Empty;': É uma boa prática! Garante que a propriedade nasça vazia em vez de 'nula' (null), evitando travamentos (NullReferenceException).
        public string Titulo { get; set; } = string.Empty;

        // Propriedade 2: Guarda a categoria do filme (ex: Ação, Terror).
        // Segue a mesma lógica de segurança da linha de cima, garantindo que não seja nulo.
        public string Genero { get; set; } = string.Empty;

        // Propriedade 3: Guarda o valor do aluguel.
        // 'decimal': É o tipo de dado obrigatório no C# quando trabalhamos com dinheiro/moeda, pois ele é extremamente preciso com os centavos (diferente do float ou double).
        public decimal PrecoDiaria { get; set; }

        // Propriedade 4: Diz se o filme pode ser alugado ou não.
        // 'bool' (booleano): Só aceita dois valores: 'true' (verdadeiro) ou 'false' (falso).
        // '= true;': Define um valor padrão. Todo filme recém-cadastrado na locadora já nasce disponível para aluguel automaticamente.
        public bool Disponivel { get; set; } = true;
    }
}