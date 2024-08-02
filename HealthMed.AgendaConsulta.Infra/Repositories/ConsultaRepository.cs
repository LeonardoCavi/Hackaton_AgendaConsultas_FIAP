using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Interfaces.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace HealthMed.AgendaConsulta.Infra.Repositories
{
    [ExcludeFromCodeCoverage]
    public class ConsultaRepository : EntidadeBaseRepository<Consulta>, IConsultaRepository
    {
        public ConsultaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
