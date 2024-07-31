using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.AgendaConsulta.Infra.Repositories
{
    public class MedicoRepository : EntidadeBaseRepository<Medico>, IMedicoRepository
    {
        public MedicoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
