using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;

namespace HealthMed.AgendaConsulta.Domain.Interfaces.Repositories
{
    public interface IPacienteRepository: IEntidadeBaseRepository<Paciente>
    {
        Task<Paciente?> Autenticar(Credencial credencial);
    }
}
