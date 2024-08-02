using HealthMed.AgendaConsulta.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace HealthMed.AgendaConsulta.Infra.Configurations
{
    [ExcludeFromCodeCoverage]
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("Paciente");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.CPF).HasColumnType("VARCHAR(11)").IsRequired();


            builder.OwnsOne(c => c.Credencial, credencialBuilder =>
            {
                credencialBuilder.ToTable("PacienteCredencial");
                credencialBuilder.Property(c => c.Email).HasColumnType("VARCHAR(100)").IsRequired();
                credencialBuilder.Property(c => c.Senha).HasColumnType("VARCHAR(100)").IsRequired();
            });

            builder.HasMany(p => p.Consultas)
                .WithOne();
        }
    }
}
