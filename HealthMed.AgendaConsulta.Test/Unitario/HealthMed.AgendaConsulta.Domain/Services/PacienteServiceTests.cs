using AutoFixture;
using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.Enums;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;
using HealthMed.AgendaConsulta.Domain.Interfaces.Notifications;
using HealthMed.AgendaConsulta.Domain.Interfaces.Repositories;
using HealthMed.AgendaConsulta.Domain.Interfaces.Services;
using HealthMed.AgendaConsulta.Domain.Interfaces.Vendor;
using HealthMed.AgendaConsulta.Domain.Notifications;
using HealthMed.AgendaConsulta.Domain.Services;
using HealthMed.AgendaConsulta.Infra.Vendor;
using HealthMed.AgendaConsulta.Test.Fake;
using NSubstitute;
using System.Linq.Expressions;

namespace HealthMed.AgendaConsulta.Test.Unitario.HealthMed.AgendaConsulta.Domain.Services
{
    public class PacienteServiceTests
    {
        public IFixture _fixture { get; set; }
        private readonly ITokenService _tokenService;
        private readonly IConsultaRepository _consultaRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMedicoRepository _medicoRepository;
        private readonly INotificador _notificador;
        private readonly IEmailManager _emailManager;
        private PacienteService _service;

        public PacienteServiceTests()
        {
            _fixture = new Fixture();
            _fixture.Customize(new MvcCostumization());

            FixtureAutoMapperConfig.AddMapperFixture(_fixture);

            _tokenService = Substitute.For<ITokenService>();
            _consultaRepository = Substitute.For<IConsultaRepository>();
            _pacienteRepository = Substitute.For<IPacienteRepository>();
            _medicoRepository = Substitute.For<IMedicoRepository>();
            _notificador = _fixture.Create<Notificador>();
            _emailManager = Substitute.For<IEmailManager>();

            _fixture.Register(() => _tokenService);
            _fixture.Register(() => _consultaRepository);
            _fixture.Register(() => _pacienteRepository);
            _fixture.Register(() => _medicoRepository);
            _fixture.Register(() => _notificador);
            _fixture.Register(() => _emailManager);

            _service = _fixture.Create<PacienteService>();
        }

        #region [ Autenticar ]

        [Fact]
        public async Task Autenticar_Teste_Sucesso()
        {
            // Arrange
            var credencial = _fixture.Create<Credencial>();
            var paciente = _fixture.Create<Paciente>();
            var token = _fixture.Create<TokenAcesso>();

            _pacienteRepository.Autenticar(credencial).Returns(paciente);
            _tokenService.GerarToken(paciente.Nome, TipoCredencial.Paciente).Returns(token);

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
            Paciente paciente = null;

            _pacienteRepository.Autenticar(credencial).Returns(paciente);

            // Act
            var resultado = await _service.Autenticar(credencial);

            // Assert
            Assert.Null(resultado);
            Assert.True(_notificador.TemNotificacao());
        }

        #endregion

        #region [ Cadastrar ]

        [Fact]
        public async Task Cadastrar_Teste_Sucesso()
        {
            // Arrange
            var paciente = new Paciente();
            ICollection<Paciente> pacientes = new List<Paciente> { paciente };
            pacientes.Clear();

            _pacienteRepository.ObterPor(Arg.Any<Expression<Func<Paciente, bool>>>()).Returns(pacientes);
            _pacienteRepository.Inserir(paciente);

            // Act
            await _service.Cadastrar(paciente);

            // Assert
            Assert.False(_notificador.TemNotificacao());
        }

        [Fact]
        public async Task Cadastrar_Teste_TemNotificao()
        {
            // Arrange
            var paciente = _fixture.Create<Paciente>();
            ICollection<Paciente> pacientes = new List<Paciente> { paciente };

            _pacienteRepository.ObterPor(Arg.Any<Expression<Func<Paciente, bool>>>()).Returns(pacientes);

            // Act
            await _service.Cadastrar(paciente);

            // Assert
            Assert.True(_notificador.TemNotificacao());
        }

        #endregion

        #region [ Buscar Medicos ]

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        public async Task BuscarMedicos_Teste_Sucesso(int day)
        {
            // Arrange
            var dia = DateTime.Now.AddDays(day);

            var horarioExpediente = new HorarioExpediente()
            {
                TrabalhaDomingo = true,
                InicioDomingo = new TimeOnly(8,0),
                FimDomingo = new TimeOnly(10,0),
                TrabalhaSegunda = true,
                InicioSegunda = new TimeOnly(8, 0),
                FimSegunda = new TimeOnly(10, 0),
                TrabalhaTerca = true,
                InicioTerca = new TimeOnly(8, 0),
                FimTerca = new TimeOnly(10, 0),
                TrabalhaQuarta = true,
                InicioQuarta = new TimeOnly(8, 0),
                FimQuarta = new TimeOnly(10, 0),
                TrabalhaQuinta = true,
                InicioQuinta = new TimeOnly(8, 0),
                FimQuinta = new TimeOnly(10, 0),
                TrabalhaSexta = true,
                InicioSexta = new TimeOnly(8, 0),
                FimSexta = new TimeOnly(10, 0),
                TrabalhaSabado = true,
                InicioSabado = new TimeOnly(8, 0),
                FimSabado = new TimeOnly(10, 0)
            };

            var medicos = _fixture.Create<List<Medico>>();
            medicos.ForEach(x =>
            {
                x.HorarioExpediente = horarioExpediente;
            });

            _medicoRepository.ObterPorDiaTrabalhado(dia.DayOfWeek).Returns(medicos);

            // Act
            var resultado = await _service.BuscarMedicos(dia);

            // Assert
            Assert.False(_notificador.TemNotificacao());
            Assert.True(resultado.All(x => x.HorariosDisponiveis.Count == 4));
        }

        [Fact]
        public async Task BuscarMedicos_Teste_TemNotificao()
        {
            // Arrange
            var dia = _fixture.Create<DateTime>();
            var medicos = new List<Medico>();

            _medicoRepository.ObterPorDiaTrabalhado(dia.DayOfWeek).Returns(medicos);

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
            var consulta = new Consulta()
            {
                MedicoId = 1,
                PacienteId = 1,
                Inicio = DateTime.Today.AddHours(9)
            };
            consulta.Fim = consulta.Inicio.AddMinutes(30);

            var paciente = new Paciente()
            {
                Id = 1,
                Consultas = new()
            };

            var medico = new Medico()
            {
                Id = 1,
                Consultas = new(),
                Credencial = new (),
                HorarioExpediente = new HorarioExpediente()
                {
                    TrabalhaDomingo = true,
                    InicioDomingo = new TimeOnly(8, 0),
                    FimDomingo = new TimeOnly(10, 0),
                    TrabalhaSegunda = true,
                    InicioSegunda = new TimeOnly(8, 0),
                    FimSegunda = new TimeOnly(10, 0),
                    TrabalhaTerca = true,
                    InicioTerca = new TimeOnly(8, 0),
                    FimTerca = new TimeOnly(10, 0),
                    TrabalhaQuarta = true,
                    InicioQuarta = new TimeOnly(8, 0),
                    FimQuarta = new TimeOnly(10, 0),
                    TrabalhaQuinta = true,
                    InicioQuinta = new TimeOnly(8, 0),
                    FimQuinta = new TimeOnly(10, 0),
                    TrabalhaSexta = true,
                    InicioSexta = new TimeOnly(8, 0),
                    FimSexta = new TimeOnly(10, 0),
                    TrabalhaSabado = true,
                    InicioSabado = new TimeOnly(8, 0),
                    FimSabado = new TimeOnly(10, 0)
                }
            };


            _medicoRepository.ObterMedicoConsultasPorId(Arg.Any<int>()).Returns(medico);
            _pacienteRepository.ObterPacienteConsultasPorId(Arg.Any<int>()).Returns(paciente);

            // Act
            await _service.AgendarConsulta(consulta);

            // Assert
            Assert.False(_notificador.TemNotificacao());
        }

        [Fact]
        public async Task AgendarConsulta_Teste_TemNotificao()
        {
            var consulta = new Consulta()
            {
                MedicoId = 1,
                PacienteId = 1,
                Inicio = DateTime.Today.AddHours(9)
            };
            consulta.Fim = consulta.Inicio.AddMinutes(30);

            Paciente paciente = null;

            Medico medico = null;

            _medicoRepository.ObterMedicoConsultasPorId(Arg.Any<int>()).Returns(medico);
            _pacienteRepository.ObterPacienteConsultasPorId(Arg.Any<int>()).Returns(paciente);

            // Act
            await _service.AgendarConsulta(consulta);

            // Assert
            Assert.True(_notificador.TemNotificacao());
        }

        #endregion [ Buscar Medicos ]
    }
}
