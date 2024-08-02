using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;
using System.Linq.Expressions;

namespace HealthMed.AgendaConsulta.Domain.Interfaces.Repositories
{
    public interface IPacienteRepository : IEntidadeBaseRepository<Paciente>
    {
        Task<Paciente?> Autenticar(Credencial credencial);
        Task<ICollection<Paciente>> ObterPor(Expression<Func<Paciente, bool>> predicate);
        Task<Paciente?> ObterPacienteConsultasPorId(int id);
    }
}
