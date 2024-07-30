using Azure;
using Azure.Communication.Email;
using HealthMed.AgendaConsulta.Infra.Vendor.Entities;

namespace HealthMed.AgendaConsulta.Infra.Vendor
{
    public class NotificationManager
    {
        private readonly AzureComunicationServiceParameters _parameters;

        public NotificationManager(AzureComunicationServiceParameters parameters)
        {
            _parameters = parameters;
        }

        public async Task SendEmailNotification(string paciente, string prestador, string destinatario, DateTime dataAgendamento)
        {
            EmailClient _email = new EmailClient(_parameters.ConnectionString);

            var titulo = "Health Med - Nova Consulta Agendada";
            var corpo = @$"<html>
                        <body>
                            <p>Olá, Dr. {prestador}!</p>
                            <p>Você tem uma nova consulta marcada!</p>
                            <p>Paciente: {paciente}.</p>
                            <p>Data e horário: {dateTime.Date.ToString("dd/MM/yyyy")} às {dataAgendamento.TimeOfDay.ToString(@"hh\:mm\:ss")}.</p>
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
                EmailMessage emailMessage = new EmailMessage(sender, dest, emailContent);

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