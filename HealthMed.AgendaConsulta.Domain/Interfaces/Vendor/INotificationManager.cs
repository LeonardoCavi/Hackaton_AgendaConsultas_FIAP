namespace HealthMed.AgendaConsulta.Domain.Interfaces.Vendor
{
    public interface INotificationManager
    {
        Task SendEmailNotification(string paciente,
                                                string prestador,
                                                string destinatario,
                                                DateTime dataAgendamento);
    }
}
