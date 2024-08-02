using Azure;
using Azure.Communication.Email;
using HealthMed.AgendaConsulta.Domain.Entities.Parameters;
using HealthMed.AgendaConsulta.Domain.Interfaces.Vendor;
using Microsoft.Extensions.Azure;

namespace HealthMed.AgendaConsulta.Infra.Vendor
{
    public class EmailManager(IAzureClientFactory<EmailClient> azureClientFactory,
                                     AzureComunicationServiceParameters parameters) : IEmailManager
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