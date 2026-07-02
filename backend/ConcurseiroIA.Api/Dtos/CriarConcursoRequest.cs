namespace ConcurseiroIA.Api.Dtos
{
    public class CriarConcursoRequest
    {
        public string Nome { get; set; } = string.Empty;

        public string Banca { get; set; } = string.Empty;

        public string Cargo { get; set; } = string.Empty;

        public DateTime DataProva { get; set; }

        public decimal HorasDisponiveisPorDia { get; set; }
    }
}