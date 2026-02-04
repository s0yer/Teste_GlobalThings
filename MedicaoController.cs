using Microsoft.AspNetCore.Mvc;
using Teste_GlobalThings_Code.Model;

namespace Teste_GlobalThings_Code.Controllers
{
    [Route("api/SensoresMedicao")]
    [ApiController]
    public class MedicaoController : ControllerBase
    {
        [HttpPost("medicoes")]
        public IActionResult ReceberMedicoes([FromBody] List<MedicaoSensor> medicoes)
        {
            if (medicoes == null || !medicoes.Any())
            {
                return BadRequest("Sem medicoes");
            }

            return Ok(new { totalProcessado = medicoes.Count });

        }

        [HttpGet("setor/{setorId}/ultimas-medicoes")]
        public async Task<IActionResult> ObterUltimasMedicoes(int setorId)
        {
           
            var resultado = await _medicaoService.ObterHistoricoPorSetorAsync(setorId);

            if (resultado == null) return NotFound("Setor nao encontrado/sem sensores vinculados.");

            return Ok(resultado);
        }


    }
}
