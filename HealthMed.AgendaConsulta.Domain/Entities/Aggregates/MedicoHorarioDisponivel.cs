namespace HealthMed.AgendaConsulta.Domain.Entities.Aggregates
{
    public class MedicoHorarioDisponivel
    {
        public Medico Medico { get; set; }
        public List<TimeOnly> HorariosDisponiveis { get; set; }
    }
}
