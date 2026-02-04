using Teste_GlobalThings_Code.Model;

namespace Teste_GlobalThings_Code.Service
{
    public class AlertaService
    {
        private const decimal LIMITE_MIN = 1m; 
        private const decimal LIMITE_MAX = 50m; 
        private const decimal MARGEM = 2m; 

        public async Task VerificarAlertas(List<MedicaoSensor> historico)
        {
            // Teste 5x fora do parametro 
            var ultimas5 = historico.OrderByDescending(m => m.DataHoraMedicao).Take(5).ToList();
            if (ultimas5.Count == 5 && ultimas5.All(m => m.Medicao < LIMITE_MIN || m.Medicao > LIMITE_MAX))
            {
                await EnviarEmail("Sensor fora da faixa por 5x seguidas");
            }

            // Media ultimas 50 medicooes
            var ultimas50 = historico.OrderByDescending(m => m.DataHoraMedicao).Take(50).ToList();
            if (ultimas50.Any())
            {
                decimal media = ultimas50.Average(m => m.Medicao); 

                // Consideracao da margem de erro
                bool margemInferior = media >= (LIMITE_MIN - MARGEM) && media <= (LIMITE_MIN + MARGEM);
                bool margemSuperior = media >= (LIMITE_MAX - MARGEM) && media <= (LIMITE_MAX + MARGEM);

                if (margemInferior || margemSuperior)
                {
                    await EnviarEmail("O Setor/Equipamento deve ser verificado"); 
                }
            }
        }

        protected virtual async Task EnviarEmail(string mensagem) => await Task.CompletedTask;
    }
}
