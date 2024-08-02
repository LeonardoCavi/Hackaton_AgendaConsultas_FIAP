using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;
using System.Linq.Expressions;

namespace HealthMed.AgendaConsulta.Domain.Interfaces.Repositories
{
    public interface IMedicoRepository : IEntidadeBaseRepository<Medico>
    {
        Task<Medico?> Autenticar(Credencial credencial);
        Task<ICollection<Medico>> ObterPor(Expression<Func<Medico, bool>> predicate);
        Task<Medico?> ObterMedicoConsultasPorId(int id);
        Task<ICollection<Medico>> ObterPorDiaTrabalhado(DayOfWeek diaSemana);
    }
}
