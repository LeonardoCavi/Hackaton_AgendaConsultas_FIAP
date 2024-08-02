using AutoFixture;
using HealthMed.AgendaConsulta.API.Controllers;
using HealthMed.AgendaConsulta.Application.Services.Interface;
using HealthMed.AgendaConsulta.Application.ViewModels;
using HealthMed.AgendaConsulta.Application.ViewModels.Paciente;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;
using HealthMed.AgendaConsulta.Domain.Interfaces.Notifications;
using HealthMed.AgendaConsulta.Domain.Notifications;
using HealthMed.AgendaConsulta.Test.Fake;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System.Net;

namespace HealthMed.AgendaConsulta.Test.Unitario.HealthMed.AgendaConsulta.API.Controllers
{
    public class PacienteControllerTests
    {
        public IFixture _fixture { get; set; }
        private readonly IPacienteApplicationService _applicationService;
        private readonly INotificador _notificador;
        private PacienteController _controller;

        public PacienteControllerTests()
        {
            _fixture = new Fixture();
            _fixture.Customize(new MvcCostumization());

            FixtureAutoMapperConfig.AddMapperFixture(_fixture);

            _applicationService = Substitute.For<IPacienteApplicationService>();
            _notificador = _fixture.Create<Notificador>();

            _fixture.Register(() => _applicationService);
            _fixture.Register(() => _notificador);

            _controller = _fixture.Create<PacienteController>();
        }

        #region [ Autenticar ]

        [Fact]
        public async Task Autenticar_Teste_Sucesso()
        {
            // Arrange
            var autenticacaoMock = _fixture.Create<AutenticacaoViewModel>();
            var tokenMock = _fixture.Create<TokenAcesso>();

            _applicationService.AutenticarPaciente(autenticacaoMock).Returns(tokenMock);

            // Act
            var resultado = await _controller.Autenticar(autenticacaoMock);
            var createdResult = resultado as CreatedResult;

            // Assert
            Assert.NotNull(createdResult);
            Assert.False(_notificador.TemNotificacao());
            Assert.Equal((int)HttpStatusCode.Created, createdResult.StatusCode);
        }

        [Fact]
        public async Task Autenticar_Teste_TemNotificao()
        {
            // Arrange
            var autenticacaoMock = _fixture.Create<AutenticacaoViewModel>();
            var tokenMock = _fixture.Create<TokenAcesso>();

            _applicationService.When(m => m.AutenticarPaciente(Arg.Any<AutenticacaoViewModel>()))
            .Do(callInfo =>
            {
                _notificador.AddNotificacao(new Notificacao("falha", TipoNotificacao.Validation));
            });

            // Act
            var resultado = await _controller.Autenticar(autenticacaoMock);
            var objectResult = resultado as ObjectResult;

            // Assert
            Assert.NotNull(objectResult);
            Assert.True(_notificador.TemNotificacao());
            Assert.Equal((int)HttpStatusCode.BadRequest, objectResult.StatusCode);
        }

        [Fact]
        public async Task Autenticar_Teste_Exception()
        {
            // Arrange
            var autenticacaoMock = _fixture.Create<AutenticacaoViewModel>();
            var tokenMock = _fixture.Create<TokenAcesso>();
            var exMock = _fixture.Create<Exception>();

            _applicationService.AutenticarPaciente(autenticacaoMock).Throws(exMock);

            // Act
            var resultado = await _controller.Autenticar(autenticacaoMock);
            var objectResult = resultado as ObjectResult;

            // Assert
            Assert.NotNull(objectResult);
            Assert.Equal((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
        }

        #endregion

        #region [ Cadastrar ]

        [Fact]
        public async Task Cadastrar_Teste_Sucesso()
        {
            // Arrange
            var cadastrarMock = _fixture.Create<CadastraPacienteViewModel>();

            _applicationService.CadastrarPaciente(cadastrarMock);

            // Act
            var resultado = await _controller.Cadastrar(cadastrarMock);
            var createdResult = resultado as CreatedResult;

            // Assert
            Assert.NotNull(createdResult);
            Assert.False(_notificador.TemNotificacao());
            Assert.Equal((int)HttpStatusCode.Created, createdResult.StatusCode);
        }

        [Fact]
        public async Task Cadastrar_Teste_TemNotificao()
        {
            // Arrange
            var cadastrarMock = _fixture.Create<CadastraPacienteViewModel>();

            _applicationService.When(m => m.CadastrarPaciente(Arg.Any<CadastraPacienteViewModel>()))
            .Do(callInfo =>
            {
                _notificador.AddNotificacao(new Notificacao("falha", TipoNotificacao.Validation));
            });

            // Act
            var resultado = await _controller.Cadastrar(cadastrarMock);
            var objectResult = resultado as ObjectResult;

            // Assert
            Assert.NotNull(objectResult);
            Assert.True(_notificador.TemNotificacao());
            Assert.Equal((int)HttpStatusCode.BadRequest, objectResult.StatusCode);
        }

        [Fact]
        public async Task Cadastrar_Teste_Exception()
        {
            // Arrange
            var cadastrarMock = _fixture.Create<CadastraPacienteViewModel>();
            var exMock = _fixture.Create<Exception>();

            _applicationService.CadastrarPaciente(cadastrarMock).Throws(exMock);

            // Act
            var resultado = await _controller.Cadastrar(cadastrarMock);
            var objectResult = resultado as ObjectResult;

            // Assert
            Assert.NotNull(objectResult);
            Assert.Equal((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
        }

        #endregion

        #region [ Buscar Medicos ]

        [Fact]
        public async Task BuscarMedicos_Teste_Sucesso()
        {
            // Arrange
            var dia = _fixture.Create<DateTime>();

            // Act
            var resultado = await _controller.BuscarMedicos(dia);
            var okResult = resultado as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.False(_notificador.TemNotificacao());
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task BuscarMedicos_Teste_TemNotificao()
        {
            // Arrange
            var dia = _fixture.Create<DateTime>();

            _applicationService.When(m => m.BuscarMedicos(Arg.Any<DateTime>()))
            .Do(callInfo =>
            {
                _notificador.AddNotificacao(new Notificacao("falha", TipoNotificacao.Validation));
            });

            // Act
            var resultado = await _controller.BuscarMedicos(dia);
            var objectResult = resultado as ObjectResult;

            // Assert
            Assert.NotNull(objectResult);
            Assert.True(_notificador.TemNotificacao());
            Assert.Equal((int)HttpStatusCode.BadRequest, objectResult.StatusCode);
        }

        [Fact]
        public async Task BuscarMedicos_Teste_Exception()
        {
            // Arrange
            var dia = _fixture.Create<DateTime>();
            var exMock = _fixture.Create<Exception>();

            _applicationService.BuscarMedicos(dia).Throws(exMock);

            // Act
            var resultado = await _controller.BuscarMedicos(dia);
            var objectResult = resultado as ObjectResult;

            // Assert
            Assert.NotNull(objectResult);
            Assert.Equal((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
        }

        #endregion

        #region [ Agendar Consulta ]

        [Fact]
        public async Task AgendarConsulta_Teste_Sucesso()
        {
            // Arrange
            var id = 1;
            var agendaConsulta = _fixture.Create<AgendaConsultaViewModel>();

            // Act
            var resultado = await _controller.AgendarConsulta(id, agendaConsulta);
            var objectResult = resultado as ObjectResult;

            // Assert
            Assert.NotNull(objectResult);
            Assert.False(_notificador.TemNotificacao());
            Assert.Equal((int)HttpStatusCode.Created, objectResult.StatusCode);
        }

        [Fact]
        public async Task AgendarConsulta_Teste_TemNotificao()
        {
            // Arrange
            var id = 1;
            var agendaConsulta = _fixture.Create<AgendaConsultaViewModel>();

            _applicationService.When(m => m.AgendarConsulta(Arg.Any<int>(), Arg.Any<AgendaConsultaViewModel>()))
            .Do(callInfo =>
            {
                _notificador.AddNotificacao(new Notificacao("falha", TipoNotificacao.Validation));
            });

            // Act
            var resultado = await _controller.AgendarConsulta(id, agendaConsulta);
            var objectResult = resultado as ObjectResult;

            // Assert
            Assert.NotNull(objectResult);
            Assert.True(_notificador.TemNotificacao());
            Assert.Equal((int)HttpStatusCode.BadRequest, objectResult.StatusCode);
        }

        [Fact]
        public async Task AgendarConsulta_Teste_Exception()
        {
            // Arrange
            var id = 1;
            var agendaConsulta = _fixture.Create<AgendaConsultaViewModel>();
            var exMock = _fixture.Create<Exception>();

            _applicationService.AgendarConsulta(id, agendaConsulta).Throws(exMock);

            // Act
            var resultado = await _controller.AgendarConsulta(id, agendaConsulta);
            var objectResult = resultado as ObjectResult;

            // Assert
            Assert.NotNull(objectResult);
            Assert.Equal((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
        }

        #endregion
    }
}
