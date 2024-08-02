using HealthMed.AgendaConsulta.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthMed.AgendaConsulta.Infra.Configurations
{
    public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("Medico");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(m => m.CPF).HasColumnType("VARCHAR(11)").IsRequired();
            builder.Property(m => m.NumeroCRM).HasColumnType("VARCHAR(15)").IsRequired();

            builder.OwnsOne(c => c.Credencial, credencialBuilder =>
            {
                credencialBuilder.ToTable("MedicoCredencial");
                credencialBuilder.Property(c => c.Email).HasColumnType("VARCHAR(100)").IsRequired();
                credencialBuilder.Property(c => c.Senha).HasColumnType("VARCHAR(100)").IsRequired();
            });

            builder.OwnsOne(m => m.HorarioExpediente, horarioExpedienteBuilder =>
            {
                horarioExpedienteBuilder.ToTable("MedicoHorarioExpediente");
                horarioExpedienteBuilder.Property(h => h.TrabalhaDomingo).HasColumnType("BIT").IsRequired();
                horarioExpedienteBuilder.Property(h => h.InicioDomingo).HasColumnType("TIME").IsRequired();
                horarioExpedienteBuilder.Property(h => h.FimDomingo).HasColumnType("TIME").IsRequired();

                horarioExpedienteBuilder.Property(h => h.TrabalhaSegunda).HasColumnType("BIT").IsRequired();
                horarioExpedienteBuilder.Property(h => h.InicioSegunda).HasColumnType("TIME").IsRequired();
                horarioExpedienteBuilder.Property(h => h.FimSegunda).HasColumnType("TIME").IsRequired();

                horarioExpedienteBuilder.Property(h => h.TrabalhaTerca).HasColumnType("BIT").IsRequired();
                horarioExpedienteBuilder.Property(h => h.InicioTerca).HasColumnType("TIME").IsRequired();
                horarioExpedienteBuilder.Property(h => h.FimTerca).HasColumnType("TIME").IsRequired();

                horarioExpedienteBuilder.Property(h => h.TrabalhaQuarta).HasColumnType("BIT").IsRequired();
                horarioExpedienteBuilder.Property(h => h.InicioQuarta).HasColumnType("TIME").IsRequired();
                horarioExpedienteBuilder.Property(h => h.FimQuarta).HasColumnType("TIME").IsRequired();

                horarioExpedienteBuilder.Property(h => h.TrabalhaQuinta).HasColumnType("BIT").IsRequired();
                horarioExpedienteBuilder.Property(h => h.InicioQuinta).HasColumnType("TIME").IsRequired();
                horarioExpedienteBuilder.Property(h => h.FimQuinta).HasColumnType("TIME").IsRequired();

                horarioExpedienteBuilder.Property(h => h.TrabalhaSexta).HasColumnType("BIT").IsRequired();
                horarioExpedienteBuilder.Property(h => h.InicioSexta).HasColumnType("TIME").IsRequired();
                horarioExpedienteBuilder.Property(h => h.FimSexta).HasColumnType("TIME").IsRequired();

                horarioExpedienteBuilder.Property(h => h.TrabalhaSabado).HasColumnType("BIT").IsRequired();
                horarioExpedienteBuilder.Property(h => h.InicioSabado).HasColumnType("TIME").IsRequired();
                horarioExpedienteBuilder.Property(h => h.FimSabado).HasColumnType("TIME").IsRequired();
            });

            builder.HasMany(m => m.Consultas);
        }
    }
}
