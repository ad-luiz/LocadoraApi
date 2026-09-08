namespace Locadora.Domain.Models
{
    public class Locacao
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int FilmeId { get; set; }
        public DateTime DataLocacao { get; set; } = DateTime.Now;
        public DateTime DataDevolucao { get; set; }
        public decimal ValorTotal { get; set; }

        public bool Devolvido { get; set; } = false;

        // Propriedades de navegação (relacionamento do banco de dados)
        public Cliente? Cliente { get; set; }
        public Filme? Filme { get; set; }
    }
}
