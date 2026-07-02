namespace ConcurseiroIA.Api.Models
{
    public class Concurso
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Banca { get; set; } = string.Empty;

        public string Cargo { get; set; } = string.Empty;

        public DateTime DataProva { get; set; }

        public decimal HorasDisponiveisPorDia { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}