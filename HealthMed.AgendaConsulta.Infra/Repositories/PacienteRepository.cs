using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;
using HealthMed.AgendaConsulta.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealthMed.AgendaConsulta.Infra.Repositories
{
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
    }
}
