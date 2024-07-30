using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;

namespace HealthMed.AgendaConsulta.Domain.Entities
{
    public class Paciente : EntidadeBase
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public Credencial Credencial { get; set; }
        public List<Consulta> Consultas { get; set; }
    }
}
