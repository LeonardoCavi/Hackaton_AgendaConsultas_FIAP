using Azure;
using Azure.Communication.Email;
using HealthMed.AgendaConsulta.Domain.Interfaces.Vendor;
using HealthMed.AgendaConsulta.Infra.Vendor.Entities;
using Microsoft.Extensions.Azure;

namespace HealthMed.AgendaConsulta.Infra.Vendor
{
    public class NotificationManager : INotificationManager
    {
        private readonly IAzureClientFactory<EmailClient> _azureClientFactory;
        private readonly AzureComunicationServiceParameters _parameters;

        public NotificationManager(AzureComunicationServiceParameters parameters,
                                    IAzureClientFactory<EmailClient> azureClientFactory)
        {
            _azureClientFactory = azureClientFactory;
            _parameters = parameters;
        }

        public async Task SendEmailNotification(string paciente,
                                                string prestador,
                                                string destinatario,
                                                DateTime dataAgendamento)
        {
            EmailClient _email = _azureClientFactory.CreateClient("MyComunicationService");

            var titulo = "Health Med - Nova Consulta Agendada";
            var corpo = @$"<html>
                        <body>
                            <p>Olá, Dr. {prestador}!</p>
                            <p>Você tem uma nova consulta marcada!</p>
                            <p>Paciente: {paciente}.</p>
                            <p>Data e horário: {dataAgendamento.Date.ToString("dd/MM/yyyy")} às {dataAgendamento.TimeOfDay.ToString(@"hh\:mm\:ss")}.</p>
                        </body>
                      </html>";
            var remetente = _parameters.Email;
            var dest = destinatario;

            try
            {
                EmailContent emailContent = new EmailContent(titulo)
                {
                    Html = corpo
                };
                EmailMessage emailMessage = new EmailMessage(remetente, dest, emailContent);

                EmailSendOperation sendEmailOp = await _email.SendAsync(WaitUntil.Completed, emailMessage);
                EmailSendResult resultado = sendEmailOp.Value;
                //Log de Sucesso
            }
            catch (Exception ex)
            {
                //Log de Falha
            }

        }
    }
}