using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.AgendaConsulta.Domain.Entities.Aggregates
{
    public class MedicoHorarioDisponivel
    {
        public Medico Medico { get; set; }
        public List<TimeOnly> HorariosDisponiveis { get; set; }
    }
}
