using Teste_GlobalThings_Code.Model;

namespace Teste_GlobalThings_Code.Service
{
    public class MedicaoService
    {
        public async Task<MedicaoSensor> ObterHistoricoPorSetorAsync(int setorId)
        {
            return await _context.Setores
                .Where(s => s.Id == setorId)
                .Select(s => new SetorMedicoesResponse
                {
                    SetorId = s.Id,
                    Sensores = s.Vinculos.Select(v => new SensorHistoricoDto
                    {
                        SensorCodigo = v.Sensor.Codigo,
                        UltimasMedicoes = v.Sensor.Medicoes
                            .OrderByDescending(m => m.DataHoraMedicao)
                            .Take(10)
                            .Select(m => new MedicaoDetalheDto
                            {
                                Valor = m.Medicao,
                                DataHora = m.DataHoraMedicao
                            }).ToList()
                    }).ToList()
                }).FirstOrDefaultAsync();
        }
    }
}