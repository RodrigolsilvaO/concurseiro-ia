using ConcurseiroIA.Api.Models;

namespace ConcurseiroIA.Api.Data
{
    public static class InMemoryDatabase
    {
        public static List<Concurso> Concursos { get; } = new();

        public static List<Disciplina> Disciplinas { get; } = new();

        public static int ProximoConcursoId { get; set; } = 1;

        public static int ProximoDisciplinaId { get; set; } = 1;
    }
}