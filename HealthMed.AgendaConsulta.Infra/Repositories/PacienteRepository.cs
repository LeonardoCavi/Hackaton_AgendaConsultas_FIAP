using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Interfaces.Repositories;

namespace HealthMed.AgendaConsulta.Infra.Repositories
{
    public class PacienteRepository : EntidadeBaseRepository<Paciente>, IPacienteRepository
    {
        public PacienteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
