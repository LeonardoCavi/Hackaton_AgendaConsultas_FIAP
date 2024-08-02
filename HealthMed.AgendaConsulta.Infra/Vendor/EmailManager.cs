using Azure;
using Azure.Communication.Email;
using HealthMed.AgendaConsulta.Domain.Entities.Parameters;
using HealthMed.AgendaConsulta.Domain.Interfaces.Notifications;
using HealthMed.AgendaConsulta.Domain.Interfaces.Vendor;
using HealthMed.AgendaConsulta.Domain.Notifications;
using HealthMed.AgendaConsulta.Domain.Notifications.Abstract;
using Microsoft.Extensions.Azure;

namespace HealthMed.AgendaConsulta.Infra.Vendor
{
    public class EmailManager(IAzureClientFactory<EmailClient> azureClientFactory,
                                     AzureComunicationServiceParameters parameters,
                                     INotificador notificador) : NotificadorContext(notificador), IEmailManager
    {
        public async Task SendEmailNotification(string nomePaciente,
                                                string nomeMedico,
                                                string destinatario,
                                                DateTime dataAgendamento)
        {
            EmailClient _email = azureClientFactory.CreateClient("MyCommunicationService");

            var titulo = "Health Med - Nova Consulta Agendada";
            var corpo = @$"<html>
                        <body>
                            <p>Olá, Dr. {nomeMedico}!</p>
                            <p>Você tem uma nova consulta marcada!</p>
                            <p>Paciente: {nomePaciente}.</p>
                            <p>Data e horário: {dataAgendamento.Date.ToString("dd/MM/yyyy")} às {dataAgendamento.TimeOfDay.ToString(@"hh\:mm\:ss")}.</p>
                        </body>
                      </html>";
            var remetente = parameters.Email;
            var dest = destinatario;

            EmailContent emailContent = new EmailContent(titulo)
            {
                Html = corpo
            };
            EmailMessage emailMessage = new EmailMessage(remetente, dest, emailContent);

            EmailSendOperation sendEmailOp = await _email.SendAsync(WaitUntil.Completed, emailMessage);

            if (sendEmailOp.HasCompleted)
                return;
            else
                Notificar("Falha no envio do email!", TipoNotificacao.Error);
        }
    }
}