using AutoFixture;
using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.Enums;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;
using HealthMed.AgendaConsulta.Domain.Interfaces.Notifications;
using HealthMed.AgendaConsulta.Domain.Interfaces.Repositories;
using HealthMed.AgendaConsulta.Domain.Interfaces.Services;
using HealthMed.AgendaConsulta.Domain.Notifications;
using HealthMed.AgendaConsulta.Domain.Services;
using HealthMed.AgendaConsulta.Test.Fake;
using NSubstitute;
using System.Linq.Expressions;

namespace HealthMed.AgendaConsulta.Test.Unitario.HealthMed.AgendaConsulta.Domain.Services
{
    public class MedicoServiceTests
    {
        public IFixture _fixture { get; set; }
        private readonly ITokenService _tokenService;
        private IMedicoRepository _repository;
        private readonly INotificador _notificador;
        private MedicoService _service;

        public MedicoServiceTests()
        {
            _fixture = new Fixture();
            _fixture.Customize(new MvcCostumization());

            FixtureAutoMapperConfig.AddMapperFixture(_fixture);

            _tokenService = Substitute.For<ITokenService>();
            _repository = Substitute.For<IMedicoRepository>();
            _notificador = _fixture.Create<Notificador>();

            _fixture.Register(() => _tokenService);
            _fixture.Register(() => _repository);
            _fixture.Register(() => _notificador);

            _service = _fixture.Create<MedicoService>();
        }

        #region [ Autenticar ]

        [Fact]
        public async Task Autenticar_Teste_Sucesso()
        {
            // Arrange
            var credencial = _fixture.Create<Credencial>();
            var medico = _fixture.Create<Medico>();
            var token = _fixture.Create<TokenAcesso>();

            _repository.Autenticar(credencial).Returns(medico);
            _tokenService.GerarToken(medico.Nome, TipoCredencial.Medico).Returns(token);

            // Act
            var resultado = await _service.Autenticar(credencial);

            // Assert
            Assert.NotNull(resultado);
            Assert.False(_notificador.TemNotificacao());
        }

        [Fact]
        public async Task Autenticar_Teste_TemNotificao()
        {
            // Arrange
            var credencial = _fixture.Create<Credencial>();
            var medico = new Medico();
            medico = null;

            _repository.Autenticar(credencial).Returns(medico);

            // Act
            var resultado = await _service.Autenticar(credencial);

            // Assert
            Assert.Null(resultado);
            Assert.True(_notificador.TemNotificacao());
        }

        #endregion [ Autenticar ]

        #region [ Cadastrar ]

        [Fact]
        public async Task Cadastrar_Teste_Sucesso()
        {
            // Arrange
            var medico = new Medico();
            ICollection<Medico> medicos = new List<Medico> { medico };
            medicos.Clear();

            _repository.ObterPor(Arg.Any<Expression<Func<Medico, bool>>>()).Returns(medicos);
            _repository.Inserir(medico);

            // Act
            await _service.Cadastrar(medico);

            // Assert
            Assert.False(_notificador.TemNotificacao());
        }

        [Fact]
        public async Task Cadastrar_Teste_TemNotificao()
        {
            // Arrange
            var medico = _fixture.Create<Medico>();
            ICollection<Medico> medicos = new List<Medico> { medico };

            _repository.ObterPor(Arg.Any<Expression<Func<Medico, bool>>>()).Returns(medicos);

            // Act
            await _service.Cadastrar(medico);

            // Assert
            Assert.True(_notificador.TemNotificacao());
        }

        #endregion [ Cadastrar ]

        #region [ Editar Expediente ]

        [Fact]
        public async Task EditarExpediente_Teste_Sucesso()
        {
            // Arrange
            int id = 1;
            var expediente = new HorarioExpediente()
            {
                TrabalhaSabado = true,
                TrabalhaSegunda = true,
                TrabalhaTerca = true,
                TrabalhaQuarta = true,
                TrabalhaQuinta = true,
                TrabalhaSexta = true,
                TrabalhaDomingo = true,
            };
            var medico = _fixture.Create<Medico>();
            medico.HorarioExpediente = expediente;

            _repository.ObterMedicoConsultasPorId(id).Returns(medico);

            // Act
            await _service.EditarExpediente(id, expediente);

            // Assert
            Assert.False(_notificador.TemNotificacao());
        }

        [Fact]
        public async Task EditarExpediente_Teste_TemNotificao()
        {
            // Arrange
            int id = 1;
            var expediente = _fixture.Create<HorarioExpediente>();
            var medico = new Medico();
            medico = null;

            _repository.Obter(id).Returns(medico);

            // Act
            await _service.EditarExpediente(id, expediente);

            // Assert
            Assert.True(_notificador.TemNotificacao());
        }

        #endregion [ Editar Expediente ]
    }
}