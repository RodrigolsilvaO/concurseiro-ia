using ConcurseiroIA.Api.Dtos;
using ConcurseiroIA.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConcurseiroIA.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConcursosController : ControllerBase
    {
        private static readonly List<Concurso> _concursos = new();
        private static int _proximoId = 1;

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_concursos);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var concurso = _concursos.FirstOrDefault(c => c.Id == id);

            if (concurso == null)
            {
                return NotFound(new
                {
                    mensagem = "Concurso não encontrado."
                });
            }

            return Ok(concurso);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] CriarConcursoRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Nome))
            {
                return BadRequest(new
                {
                    mensagem = "O nome do concurso é obrigatório."
                });
            }

            if (request.DataProva.Date < DateTime.Today)
            {
                return BadRequest(new
                {
                    mensagem = "A data da prova não pode ser anterior à data atual."
                });
            }

            if (request.HorasDisponiveisPorDia <= 0)
            {
                return BadRequest(new
                {
                    mensagem = "As horas disponíveis por dia devem ser maiores que zero."
                });
            }

            var concurso = new Concurso
            {
                Id = _proximoId++,
                Nome = request.Nome,
                Banca = request.Banca,
                Cargo = request.Cargo,
                DataProva = request.DataProva,
                HorasDisponiveisPorDia = request.HorasDisponiveisPorDia,
                CriadoEm = DateTime.Now
            };

            _concursos.Add(concurso);

            return CreatedAtAction(nameof(ObterPorId), new { id = concurso.Id }, concurso);
        }
    }
}