using HealthMed.AgendaConsulta.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthMed.AgendaConsulta.Infra.Configurations
{
    public class ConsultaConfiguration : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.ToTable("Consulta");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Inicio).HasColumnType("DATETIME2").IsRequired();
            builder.Property(c => c.Fim).HasColumnType("DATETIME2").IsRequired();
        }
    }
}
