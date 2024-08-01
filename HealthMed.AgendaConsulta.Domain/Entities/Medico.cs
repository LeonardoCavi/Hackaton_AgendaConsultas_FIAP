using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;

namespace HealthMed.AgendaConsulta.Domain.Entities
{
    public class Medico : EntidadeBase
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string NumeroCRM { get; set; }
        public Credencial Credencial { get; set; }
        public HorarioExpediente? HorarioExpediente { get; set; }
        public List<Consulta> Consultas { get; set; }
    }
}
