using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace Teste_GlobalThings_Code.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Setor> Setores { get; set; }
        public DbSet<Sensor> Sensores { get; set; }
        public DbSet<Medicao> Medicoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da Medicao conforme requisitos da Parte 1
            modelBuilder.Entity<Medicao>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Medida).HasPrecision(18, 2);
                entity.Property(e => e.DataHoraMedicao).IsRequired();
        });

        // Configuração do Vínculo (Parte 2: Setor/Equipamento -> Sensor)
        modelBuilder.Entity<Sensor>()
            .HasOne(s => s.Setor)
            .WithMany(st => st.Sensores)
            .HasForeignKey(s => s.SetorId)
            .OnDelete(DeleteBehavior.Restrict);
    }



        // Entidades de Domínio
        public class Setor
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public List<Sensor> Sensores { get; set; }

        }

        public class Sensor
        {
            public int Id { get; set; }
            public string Codigo { get; set; }
            public int? SetorId { get; set; } // FK para vínculo da Parte 2 
            public Setor Setor { get; set; }
            public List<Medicao> Medicoes { get; set; }

        }

        public class Medicao
        {
            public int Id { get; set; }
            public int SensorId { get; set; }
            public string Codigo { get; set; }
            public DateTimeOffset DataHoraMedicao { get; set; }
            public decimal Medida { get; set; }

        }

        // DTOs
        public class SetorMedicoesResponse
        {
            public int SetorId { get; set; }
            public List<SensorHistoricoDto> Sensores { get; set; }
        }

        public class SensorHistoricoDto
        {
            public string SensorCodigo { get; set; }
            public List<MedicaoDetalheDto> UltimasMedicoes { get; set; }
        }

        public class MedicaoDetalheDto
        {
            public decimal Valor { get; set; }
            public DateTimeOffset DataHora { get; set; }
        }


    }


}
