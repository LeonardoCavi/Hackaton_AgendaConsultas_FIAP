using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;

namespace HealthMed.AgendaConsulta.Domain.Interfaces.Repositories
{
    public interface IMedicoRepository : IEntidadeBaseRepository<Medico>
    {
        Task<Medico?> Autenticar(Credencial credencial);
    }
}
