using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;
using HealthMed.AgendaConsulta.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace HealthMed.AgendaConsulta.Infra.Repositories
{
    [ExcludeFromCodeCoverage]
    public class PacienteRepository : EntidadeBaseRepository<Paciente>, IPacienteRepository
    {
        public PacienteRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Paciente?> Autenticar(Credencial credencial)
        {
            return await _context.Pacientes
                .Include(m => m.Credencial)
                .Where(m => m.Credencial.Email == credencial.Email && m.Credencial.Senha == credencial.Senha)
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<Paciente>> ObterPor(Expression<Func<Paciente, bool>> predicate)
        {
            return await _dBSet
                .Include(x => x.Credencial)
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<Paciente?> ObterPacienteConsultasPorId(int id)
        {
            return await _dBSet
                .Include(x => x.Consultas)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
