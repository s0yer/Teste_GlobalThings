using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste_GlobalThings_Code.Model;

namespace Teste_GlobalThings_Code.Controllers
{
    [Route("api/ConfiguracaoVinculo")]
    [ApiController]
    public class VinculoController : ControllerBase
    {
        [HttpPost("vincular")]
        public IActionResult VincularSensor([FromBody] VinculoRequisicao request)
        {
            if (request.SensorId <= 0 || request.SetorEquipamentoId <= 0)
                return BadRequest("IDs inválidos.");

            // Chama Service de Persistencia no banco de dados

            return Ok(new { message = "Vínculo realizado com sucesso!" });
        }
    }
}
