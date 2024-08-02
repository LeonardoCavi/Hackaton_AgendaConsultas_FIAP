namespace HealthMed.AgendaConsulta.Application.ViewModels.Paciente
{
    public class BuscaMedicoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NumeroCRM { get; set; }
        public List<TimeOnly> HorariosDisponiveis { get; set; }
    }
}
