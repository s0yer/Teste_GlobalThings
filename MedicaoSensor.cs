namespace Teste_GlobalThings_Code.Model
{
    public class MedicaoSensor
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public DateTimeOffset DataHoraMedicao { get; set; }
        public decimal Medicao { get; set; }
    }
}
