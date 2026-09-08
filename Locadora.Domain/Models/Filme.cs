namespace Locadora.Domain.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;

        public decimal PrecoDiaria { get; set; }
        public bool Disponivel { get; set; } = true;
    }
}
