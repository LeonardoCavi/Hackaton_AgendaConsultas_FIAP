using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;
using HealthMed.AgendaConsulta.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace HealthMed.AgendaConsulta.Infra.Repositories
{
    [ExcludeFromCodeCoverage]
    public class MedicoRepository : EntidadeBaseRepository<Medico>, IMedicoRepository
    {
        public MedicoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Medico?> Autenticar(Credencial credencial)
        {
            return await _context.Medicos
                    .Include(m => m.Credencial)
                    .Where(m => m.Credencial.Email == credencial.Email && m.Credencial.Senha == credencial.Senha)
                    .FirstOrDefaultAsync();
        }

        public async Task<ICollection<Medico>> ObterPor(Expression<Func<Medico, bool>> predicate)
        {
            return await _dBSet
                .Include(x => x.Credencial)
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<Medico?> ObterMedicoConsultasPorId(int id)
        {
            return await _dBSet
                .Include(x => x.HorarioExpediente)
                .Include(x => x.Consultas)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<Medico>> ObterPorDiaTrabalhado(DayOfWeek diaSemana)
        {
            return await _dBSet
                .Include(x => x.HorarioExpediente)
                .Include(x => x.Consultas)
                .Where(medico =>
                    (diaSemana == DayOfWeek.Saturday && medico.HorarioExpediente.TrabalhaSabado) ||
                    (diaSemana == DayOfWeek.Monday && medico.HorarioExpediente.TrabalhaSegunda) ||
                    (diaSemana == DayOfWeek.Tuesday && medico.HorarioExpediente.TrabalhaTerca) ||
                    (diaSemana == DayOfWeek.Wednesday && medico.HorarioExpediente.TrabalhaQuarta) ||
                    (diaSemana == DayOfWeek.Thursday && medico.HorarioExpediente.TrabalhaQuinta) ||
                    (diaSemana == DayOfWeek.Friday && medico.HorarioExpediente.TrabalhaSexta) ||
                    (diaSemana == DayOfWeek.Sunday && medico.HorarioExpediente.TrabalhaDomingo))
                .ToListAsync();
        }
    }
}
