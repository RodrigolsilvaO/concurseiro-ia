namespace ConcurseiroIA.Api.Models
{
    public class Disciplina
    {
        public int Id { get; set; }

        public int ConcursoId { get; set; }

        public string Nome { get; set; } = string.Empty;

        public int Peso { get; set; }

        public int Dificuldade { get; set; }

        public string Prioridade { get; set; } = string.Empty;

        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}