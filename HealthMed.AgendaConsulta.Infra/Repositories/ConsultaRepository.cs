using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Interfaces.Repositories;

namespace HealthMed.AgendaConsulta.Infra.Repositories
{
    public class ConsultaRepository : EntidadeBaseRepository<Consulta>, IConsultaRepository
    {
        public ConsultaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
