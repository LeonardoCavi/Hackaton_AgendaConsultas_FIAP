namespace HealthMed.AgendaConsulta.Domain.Interfaces.Vendor
{
    public interface IEmailManager
    {
        Task SendEmailNotification(string nomePaciente,
                                                string nomeMedico,
                                                string destinatario,
                                                DateTime dataAgendamento);
    }
}
