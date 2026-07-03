namespace ConcurseiroIA.Api.Dtos
{
    public class CriarDisciplinaRequest
    {
        public string Nome { get; set; } = string.Empty;

        public int Peso { get; set; }

        public int Dificuldade { get; set; }

        public string Prioridade { get; set; } = string.Empty;
    }
}
