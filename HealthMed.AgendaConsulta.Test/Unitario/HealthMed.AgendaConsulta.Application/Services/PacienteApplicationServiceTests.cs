using AutoFixture;
using HealthMed.AgendaConsulta.Application.Services;
using HealthMed.AgendaConsulta.Application.ViewModels;
using HealthMed.AgendaConsulta.Application.ViewModels.Medico;
using HealthMed.AgendaConsulta.Application.ViewModels.Paciente;
using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.Aggregates;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;
using HealthMed.AgendaConsulta.Domain.Interfaces.Notifications;
using HealthMed.AgendaConsulta.Domain.Interfaces.Services;
using HealthMed.AgendaConsulta.Domain.Notifications;
using HealthMed.AgendaConsulta.Domain.Services;
using HealthMed.AgendaConsulta.Test.Fake;
using Newtonsoft.Json;
using NSubstitute;

namespace HealthMed.AgendaConsulta.Test.Unitario.HealthMed.AgendaConsulta.Application.Services
{
    public class PacienteApplicationServiceTests
    {
        public IFixture _fixture { get; set; }
        private readonly IPacienteService _pacienteService;
        private readonly INotificador _notificador;
        private PacienteApplicationService _service;

        public PacienteApplicationServiceTests()
        {
            _fixture = new Fixture();
            _fixture.Customize(new MvcCostumization());

            FixtureAutoMapperConfig.AddMapperFixture(_fixture);

            _pacienteService = Substitute.For<IPacienteService>();
            _notificador = _fixture.Create<Notificador>();

            _fixture.Register(() => _pacienteService);
            _fixture.Register(() => _notificador);

            _service = _fixture.Create<PacienteApplicationService>();
        }

        #region [ Autenticar ]

        [Fact]
        public async Task AutenticarPaciente_Teste_Sucesso()
        {
            // Arrange
            var credencialsMock = _fixture.Create<AutenticacaoViewModel>();
            var tokenMock = _fixture.Create<TokenAcesso>();

            _pacienteService.Autenticar(Arg.Any<Credencial>()).Returns(tokenMock);

            // Act
            var resultado = await _service.AutenticarPaciente(credencialsMock);

            // Assert
            Assert.NotNull(resultado);
            Assert.False(_notificador.TemNotificacao());
        }

        [Fact]
        public async Task AutenticarPaciente_Teste_TemNotificao()
        {
            // Arrange
            var credencialsMock = new AutenticacaoViewModel
            {
                Email = "",
                Senha = ""
            };

            // Act
            var resultado = await _service.AutenticarPaciente(credencialsMock);

            // Assert
            Assert.Null(resultado);
            Assert.True(_notificador.TemNotificacao());
        }

        #endregion

        #region [ Cadastrar ] 

        [Fact]
        public async Task CadastrarPaciente_Teste_Sucesso()
        {
            // Arrange
            var pacienteMock = _fixture.Create<CadastraPacienteViewModel>();

            // Act
            await _service.CadastrarPaciente(pacienteMock);

            // Assert
            Assert.False(_notificador.TemNotificacao());
        }

        [Fact]
        public async Task CadastrarPaciente_Teste_TemNotificao()
        {
            // Arrange
            var pacienteMock = new CadastraPacienteViewModel
            {
                CPF = "",
                Nome = ""
            };

            // Act
            await _service.CadastrarPaciente(pacienteMock);

            // Assert
            Assert.True(_notificador.TemNotificacao());
        }

        #endregion

        #region [ Buscar Medicos ]

        [Fact]
        public async Task BuscarMedicos_Teste_Sucesso()
        {
            // Arrange
            var dia = _fixture.Create<DateTime>();

            _pacienteService.BuscarMedicos(dia)
                .Returns(_fixture.Create<List<MedicoHorarioDisponivel>>());

            // Act
            await _service.BuscarMedicos(dia);

            // Assert
            Assert.False(_notificador.TemNotificacao());
        }

        [Fact]
        public async Task BuscarMedicos_Teste_TemNotificao()
        {
            // Arrange
            var dia = DateTime.MinValue;

            // Act
            await _service.BuscarMedicos(dia);

            // Assert
            Assert.True(_notificador.TemNotificacao());
        }

        #endregion

        #region [ Agendar Consulta ]

        [Fact]
        public async Task AgendarConsulta_Teste_Sucesso()
        {
            // Arrange
            var id = 1;
            var agendaConsulta = _fixture.Create<AgendaConsultaViewModel>();
            agendaConsulta.InicioConsulta = DateTime.Now.AddDays(1);

            // Act
            await _service.AgendarConsulta(id, agendaConsulta);

            // Assert
            Assert.False(_notificador.TemNotificacao());
        }

        [Fact]
        public async Task AgendarConsulta_Teste_TemNotificao()
        {
            // Arrange
            var id = 1;
            var agendaConsulta = _fixture.Create<AgendaConsultaViewModel>();
            agendaConsulta.InicioConsulta = DateTime.Now.AddDays(-1);

            // Act
            await _service.AgendarConsulta(id, agendaConsulta);

            // Assert
            Assert.True(_notificador.TemNotificacao());
        }

        #endregion
    }
}
