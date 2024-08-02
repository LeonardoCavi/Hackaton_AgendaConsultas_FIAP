using AutoFixture;
using HealthMed.AgendaConsulta.Application.Services;
using HealthMed.AgendaConsulta.Application.ViewModels;
using HealthMed.AgendaConsulta.Application.ViewModels.Medico;
using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;
using HealthMed.AgendaConsulta.Domain.Interfaces.Notifications;
using HealthMed.AgendaConsulta.Domain.Interfaces.Services;
using HealthMed.AgendaConsulta.Domain.Notifications;
using HealthMed.AgendaConsulta.Test.Fake;
using Newtonsoft.Json;
using NSubstitute;

namespace HealthMed.AgendaConsulta.Test.Unitario.HealthMed.AgendaConsulta.Application.Services
{
    public class MedicoApplicationServiceTests
    {
        public IFixture _fixture { get; set; }
        private readonly IMedicoService _medicoService;
        private readonly INotificador _notificador;
        private MedicoApplicationService _service;

        public MedicoApplicationServiceTests()
        {
            _fixture = new Fixture();
            _fixture.Customize(new MvcCostumization());

            FixtureAutoMapperConfig.AddMapperFixture(_fixture);

            _medicoService = Substitute.For<IMedicoService>();
            _notificador = _fixture.Create<Notificador>();

            _fixture.Register(() => _medicoService);
            _fixture.Register(() => _notificador);

            _service = _fixture.Create<MedicoApplicationService>();
        }

        #region [ Autenticar ]

        [Fact]
        public async Task AutenticarMedico_Teste_Sucesso()
        {
            // Arrange
            var credencialsMock = _fixture.Create<AutenticacaoViewModel>();
            var tokenMock = _fixture.Create<TokenAcesso>();

            _medicoService.Autenticar(Arg.Any<Credencial>()).Returns(tokenMock);

            // Act
            var resultado = await _service.AutenticarMedico(credencialsMock);

            // Assert
            Assert.NotNull(resultado);
            Assert.False(_notificador.TemNotificacao());
        }

        [Fact]
        public async Task AutenticarMedico_Teste_TemNotificao()
        {
            // Arrange
            var credencialsMock = new AutenticacaoViewModel
            {
                Email = "",
                Senha = ""
            };

            // Act
            var resultado = await _service.AutenticarMedico(credencialsMock);

            // Assert
            Assert.Null(resultado);
            Assert.True(_notificador.TemNotificacao());
        }

        #endregion

        #region [ Cadastrar ] 

        [Fact]
        public async Task CadastrarMedico_Teste_Sucesso()
        {
            // Arrange
            var medicoMock = _fixture.Create<CadastraMedicoViewModel>();
            var medico = _fixture.Create<Medico>();

            _medicoService.Cadastrar(Arg.Any<Medico>());

            // Act
            await _service.CadastrarMedico(medicoMock);

            // Assert
            Assert.False(_notificador.TemNotificacao());
        }

        [Fact]
        public async Task CadastrarMedico_Teste_TemNotificao()
        {
            // Arrange
            var medicoMock = new CadastraMedicoViewModel
            {
                CPF = "",
                Nome = ""
            };

            // Act
            await _service.CadastrarMedico(medicoMock);

            // Assert
            Assert.True(_notificador.TemNotificacao());
        }

        #endregion

        #region [ Editar Expediente ]

        [Fact]
        public async Task EditarExpediente_Teste_Sucesso()
        {
            // Arrange
            int id = 1;
            var json = @"{
              ""trabalhaDomingo"": true,
              ""inicioDomingo"": ""01:25:38"",
              ""fimDomingo"": ""03:25:38"",
              ""trabalhaSegunda"": true,
              ""inicioSegunda"": ""01:25:38"",
              ""fimSegunda"": ""03:25:38"",
              ""trabalhaTerca"": true,
              ""inicioTerca"": ""01:25:38"",
              ""fimTerca"": ""03:25:38"",
              ""trabalhaQuarta"": true,
              ""inicioQuarta"": ""01:25:38"",
              ""fimQuarta"": ""03:25:38"",
              ""trabalhaQuinta"": true,
              ""inicioQuinta"": ""01:25:38"",
              ""fimQuinta"": ""03:25:38"",
              ""trabalhaSexta"": true,
              ""inicioSexta"": ""01:25:38"",
              ""fimSexta"": ""03:25:38"",
              ""trabalhaSabado"": true,
              ""inicioSabado"": ""01:25:38"",
              ""fimSabado"": ""03:25:38""
            }";
            var expedienteMock = JsonConvert.DeserializeObject<EditaExpedienteViewModel>(json);
            var expediente = _fixture.Create<HorarioExpediente>();

            _medicoService.EditarExpediente(id, expediente);

            // Act
            await _service.EditarExpediente(id, expedienteMock);

            // Assert
            Assert.False(_notificador.TemNotificacao());
        }

        [Fact]
        public async Task EditarExpediente_Teste_TemNotificao()
        {
            // Arrange
            int id = 1;
            var expedienteMock = new EditaExpedienteViewModel
            {
                TrabalhaDomingo = true,
                InicioDomingo = TimeOnly.MaxValue,
                FimDomingo = TimeOnly.MinValue
            };

            // Act
            await _service.EditarExpediente(id, expedienteMock);

            // Assert
            Assert.True(_notificador.TemNotificacao());
        }

        #endregion
    }
}
