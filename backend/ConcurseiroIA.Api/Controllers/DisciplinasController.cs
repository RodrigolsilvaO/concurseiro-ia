using ConcurseiroIA.Api.Data;
using ConcurseiroIA.Api.Dtos;
using ConcurseiroIA.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConcurseiroIA.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class DisciplinasController : ControllerBase
    {
        [HttpGet("concursos/{concursoId:int}/disciplinas")]
        public IActionResult ListarPorConcurso(int concursoId)
        {
            var concursoExiste = InMemoryDatabase.Concursos.Any(c => c.Id == concursoId);

            if (!concursoExiste)
            {
                return NotFound(new
                {
                    mensagem = "Concurso não encontrado."
                });
            }

            var disciplinas = InMemoryDatabase.Disciplinas
                .Where(d => d.ConcursoId == concursoId)
                .ToList();

            return Ok(disciplinas);
        }

        [HttpGet("disciplinas/{id:int}")]
        public IActionResult ObterPorId(int id)
        {
            var disciplina = InMemoryDatabase.Disciplinas.FirstOrDefault(d => d.Id == id);

            if (disciplina == null)
            {
                return NotFound(new
                {
                    mensagem = "Disciplina não encontrada."
                });
            }

            return Ok(disciplina);
        }

        [HttpPost("concursos/{concursoId:int}/disciplinas")]
        public IActionResult Criar(int concursoId, [FromBody] CriarDisciplinaRequest request)
        {
            var concursoExiste = InMemoryDatabase.Concursos.Any(c => c.Id == concursoId);

            if (!concursoExiste)
            {
                return NotFound(new
                {
                    mensagem = "Concurso não encontrado."
                });
            }

            if (string.IsNullOrWhiteSpace(request.Nome))
            {
                return BadRequest(new
                {
                    mensagem = "O nome da disciplina é obrigatório."
                });
            }

            if (request.Peso < 1 || request.Peso > 5)
            {
                return BadRequest(new
                {
                    mensagem = "O peso deve ser um valor entre 1 e 5."
                });
            }

            if (request.Dificuldade < 1 || request.Dificuldade > 5)
            {
                return BadRequest(new
                {
                    mensagem = "A dificuldade deve ser um valor entre 1 e 5."
                });
            }

            var disciplina = new Disciplina
            {
                Id = InMemoryDatabase.ProximoDisciplinaId++,
                ConcursoId = concursoId,
                Nome = request.Nome,
                Peso = request.Peso,
                Dificuldade = request.Dificuldade,
                Prioridade = request.Prioridade,
                CriadoEm = DateTime.Now
            };

            InMemoryDatabase.Disciplinas.Add(disciplina);

            return CreatedAtAction(nameof(ObterPorId), new { id = disciplina.Id }, disciplina);
        }
    }
}