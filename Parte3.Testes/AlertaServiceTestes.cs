using Teste_GlobalThings_Code.Model;
using Teste_GlobalThings_Code.Service;

namespace Parte3.Testes
{
    public class AlertaServiceTestes
    {
        [Fact]
        public async Task Deve_Disparar_AlertaCritico_Quando_5_Medicoes_Consecutivas_Acima_50()
        {
            
            var service = new AlertaService();
            var dados = Enumerable.Range(1, 5).Select(i => new MedicaoSensor { Medicao = 51m }).ToList();

            // simula verificacao de Alerta
            // Usar Mock para servico de email, em cenario real

            await service.VerificarAlertas(dados);
        }

        [Fact]
        public async Task Deve_Disparar_Atencao_Quando_Media_50_Dentro_Da_Margem()
        {
            // Margem de Erro
            var service = new AlertaService();
            var dados = Enumerable.Range(1, 50).Select(i => new MedicaoSensor { Medicao = 49m }).ToList();

            
            await service.VerificarAlertas(dados);
        }

        [Fact]
        public async Task Nao_Deve_Disparar_Alerta_Se_Valores_Estiverem_Normais()
        {
            // Valores Normais
            var service = new AlertaService();
            var dados = Enumerable.Range(1, 50).Select(i => new MedicaoSensor { Medicao = 25m }).ToList();

            
            await service.VerificarAlertas(dados);
        }

    }
}
