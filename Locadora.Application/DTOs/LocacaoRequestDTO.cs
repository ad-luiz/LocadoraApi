using System;
using System.Collections.Generic;
using System.Text;

namespace Locadora.Application.DTOs
{
    public class LocacaoRequestDTO
    {
        public int ClienteId { get; set; }
        public int FilmeId { get; set; }
    }
}
