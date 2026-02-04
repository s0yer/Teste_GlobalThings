namespace Teste_GlobalThings_Code.Model
{
    public class MedicaoSensor
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public DateTimeOffset DataHoraMedicao { get; set; }
        public decimal Medicao { get; set; }
    }

    public class SensorHistoricoDto
    {
        public int SensorId { get; set; }
        public string Codigo { get; set; }
        public List<MedicaoDetalheDto> UltimasMedicoes { get; set; }
    }

    public class MedicaoDetalheDto
    {
        public decimal Valor { get; set; }
        public DateTimeOffset DataHora { get; set; }
    }
}
