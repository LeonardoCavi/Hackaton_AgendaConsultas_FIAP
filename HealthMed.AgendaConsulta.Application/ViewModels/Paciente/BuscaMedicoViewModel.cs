namespace HealthMed.AgendaConsulta.Application.ViewModels.Paciente
{
    public class BuscaMedicoViewModel
    {
        public DateTime Dia { get; set; }
        public List<Domain.Entities.Medico> Medicos { get; set; }
    }
}
