using AutoFixture;
using HealthMed.AgendaConsulta.API.Controllers;
using HealthMed.AgendaConsulta.Application.Services.Interface;
using HealthMed.AgendaConsulta.Application.ViewModels;
using HealthMed.AgendaConsulta.Application.ViewModels.Medico;
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
    public class MedicoControllerTests
    {
        public IFixture _fixture { get; set; }
        private readonly IMedicoApplicationService _applicationService;
        private readonly INotificador _notificador;
        private MedicoController _controller;

        public MedicoControllerTests()
        {
            _fixture = new Fixture();
            _fixture.Customize(new MvcCostumization());

            FixtureAutoMapperConfig.AddMapperFixture(_fixture);

            _applicationService = Substitute.For<IMedicoApplicationService>();
            _notificador = _fixture.Create<Notificador>();

            _fixture.Register(() => _applicationService);
            _fixture.Register(() => _notificador);

            _controller = _fixture.Create<MedicoController>();
        }

        #region [ Autenticar ]

        [Fact]
        public async Task Autenticar_Teste_Sucesso()
        {
            // Arrange
            var autenticacaoMock = _fixture.Create<AutenticacaoViewModel>();
            var tokenMock = _fixture.Create<TokenAcesso>();

            _applicationService.AutenticarMedico(autenticacaoMock).Returns(tokenMock);

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

            _applicationService.When(m => m.AutenticarMedico(Arg.Any<AutenticacaoViewModel>()))
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

            _applicationService.AutenticarMedico(autenticacaoMock).Throws(exMock);

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
            var cadastrarMock = _fixture.Create<CadastraMedicoViewModel>();

            _applicationService.CadastrarMedico(cadastrarMock);

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
            var cadastrarMock = _fixture.Create<CadastraMedicoViewModel>();

            _applicationService.When(m => m.CadastrarMedico(Arg.Any<CadastraMedicoViewModel>()))
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
            var cadastrarMock = _fixture.Create<CadastraMedicoViewModel>();
            var exMock = _fixture.Create<Exception>();

            _applicationService.CadastrarMedico(cadastrarMock).Throws(exMock);

            // Act
            var resultado = await _controller.Cadastrar(cadastrarMock);
            var objectResult = resultado as ObjectResult;

            // Assert
            Assert.NotNull(objectResult);
            Assert.Equal((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
        }

        #endregion

        #region [ Editar Expediente ]

        [Fact]
        public async Task EditarExpediente_Teste_Sucesso()
        {
            // Arrange
            int id = 1;
            var expedienteMock = _fixture.Create<EditaExpedienteViewModel>();

            _applicationService.EditarExpediente(id, expedienteMock);

            // Act
            var resultado = await _controller.EditarExpediente(id, expedienteMock);
            var okResult = resultado as OkResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.False(_notificador.TemNotificacao());
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task EditarExpediente_Teste_TemNotificao()
        {
            // Arrange
            int id = 1;
            var expedienteMock = _fixture.Create<EditaExpedienteViewModel>();

            _applicationService.When(m => m.EditarExpediente(Arg.Any<int>(), Arg.Any<EditaExpedienteViewModel>()))
            .Do(callInfo =>
            {
                _notificador.AddNotificacao(new Notificacao("falha", TipoNotificacao.Validation));
            });

            // Act
            var resultado = await _controller.EditarExpediente(id, expedienteMock);
            var objectResult = resultado as ObjectResult;

            // Assert
            Assert.NotNull(objectResult);
            Assert.True(_notificador.TemNotificacao());
            Assert.Equal((int)HttpStatusCode.BadRequest, objectResult.StatusCode);
        }

        [Fact]
        public async Task EditarExpediente_Teste_Exception()
        {
            // Arrange
            int id = 1;
            var expedienteMock = _fixture.Create<EditaExpedienteViewModel>();
            var exMock = _fixture.Create<Exception>();

            _applicationService.EditarExpediente(id, expedienteMock).Throws(exMock);

            // Act
            var resultado = await _controller.EditarExpediente(id, expedienteMock);
            var objectResult = resultado as ObjectResult;

            // Assert
            Assert.NotNull(objectResult);
            Assert.Equal((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
        }

        #endregion
    }
}