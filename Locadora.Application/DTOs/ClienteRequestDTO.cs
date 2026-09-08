using System;
using System.Collections.Generic;
using System.Text;

namespace Locadora.Application.DTOs
{
    public class ClienteRequestDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Cpf {  get; set; } = string.Empty;
        public string Email {  get; set; } = string.Empty;
        public string Telefone {  get; set; } = string.Empty;
    }
}
