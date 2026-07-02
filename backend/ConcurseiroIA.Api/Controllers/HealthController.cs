using Microsoft.AspNetCore.Mvc;

namespace ConcurseiroIA.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                status = "API funcionando",
                projeto = "ConcurseiroIA",
                mensagem = "Backend inicial criado com sucesso",
                dataHora = DateTime.Now
            });
        }
    }
}