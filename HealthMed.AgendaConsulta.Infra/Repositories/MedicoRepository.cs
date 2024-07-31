using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;
using HealthMed.AgendaConsulta.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealthMed.AgendaConsulta.Infra.Repositories
{
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
    }
}
