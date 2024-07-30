using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.AgendaConsulta.Domain.Entities
{
    public class Medico : EntidadeBase
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string NumeroCRM { get; set; }
        public Credencial Credencial { get; set; }
        public HorarioExpediente HorarioExpediente { get; set; }
        public List<Consulta> Consultas { get; set; }
    }
}
