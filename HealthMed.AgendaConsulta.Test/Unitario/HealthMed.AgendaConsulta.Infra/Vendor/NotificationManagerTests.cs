using AutoFixture;
using Azure;
using Azure.Communication.Email;
using HealthMed.AgendaConsulta.Domain.Entities.Parameters;
using HealthMed.AgendaConsulta.Domain.Interfaces.Notifications;
using HealthMed.AgendaConsulta.Domain.Notifications;
using HealthMed.AgendaConsulta.Infra.Vendor;
using HealthMed.AgendaConsulta.Test.Fake;
using Microsoft.Extensions.Azure;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace HealthMed.AgendaConsulta.Test.Unitario.HealthMed.AgendaConsulta.Infra.Vendor
{
    public class NotificationManagerTests
    {
        public IFixture _fixture { get; set; }
        private readonly AzureComunicationServiceParameters _parameters;
        private readonly IAzureClientFactory<EmailClient> _azureClientFactory;
        private readonly INotificador _notificador;
        private readonly EmailClient _email;
        private NotificationManager _manager;

        public NotificationManagerTests()
        {
            _fixture = new Fixture();
            _fixture.Customize(new MvcCostumization());

            FixtureAutoMapperConfig.AddMapperFixture(_fixture);

            _parameters = Substitute.For<AzureComunicationServiceParameters>();
            _parameters = _fixture.Create<AzureComunicationServiceParameters>();
            _azureClientFactory = Substitute.For<IAzureClientFactory<EmailClient>>();
            _email = Substitute.For<EmailClient>();
            _notificador = _fixture.Create<Notificador>();

            _fixture.Register(() => _parameters);
            _fixture.Register(() => _azureClientFactory);
            _fixture.Register(() => _email);
            _fixture.Register(() => _notificador);

            _manager = _fixture.Create<NotificationManager>();
        }

        //[Fact]
        //public async Task SendEmailNotification_Teste_Sucesso()
        //{
        //    // Arrange
        //    string paciente = "teste_p";
        //    string prestador = "teste_m";
        //    string destinatario = "teste@teste.com";
        //    DateTime dataAgendamento = DateTime.Now;

        //    var sendOp = _fixture.Create<EmailSendOperation>();
        //    var emailMessage = _fixture.Create<EmailMessage>();

        //    _email.SendAsync(WaitUntil.Completed, emailMessage).Returns(sendOp);

        //    // Act
        //    await _manager.SendEmailNotification(paciente, prestador, destinatario, dataAgendamento);

        //    // Assert
        //    Assert.False(_notificador.TemNotificacao());
        //}

        //[Fact]
        //public async Task SendEmailNotification_Teste_TemNotificacao()
        //{
        //    // Arrange
        //    string paciente = "teste_p";
        //    string prestador = "teste_m";
        //    string destinatario = "teste@teste.com";
        //    DateTime dataAgendamento = DateTime.Now;

        //    var emailMessage = _fixture.Create<EmailMessage>();

        //    _email.SendAsync(WaitUntil.Completed, emailMessage).Throws(new Exception("exception dos deuses"));

        //    // Act
        //    await _manager.SendEmailNotification(paciente, prestador, destinatario, dataAgendamento);

        //    // Assert
        //    Assert.True(_notificador.TemNotificacao());
        //}
    }
}