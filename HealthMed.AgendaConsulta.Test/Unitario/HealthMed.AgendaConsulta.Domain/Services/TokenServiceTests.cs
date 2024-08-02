using AutoFixture;
using HealthMed.AgendaConsulta.Domain.Entities.Enums;
using HealthMed.AgendaConsulta.Domain.Entities.Parameters;
using HealthMed.AgendaConsulta.Domain.Services;
using HealthMed.AgendaConsulta.Test.Fake;
using NSubstitute;

namespace HealthMed.AgendaConsulta.Test.Unitario.HealthMed.AgendaConsulta.Domain.Services
{
    public class TokenServiceTests
    {
        public IFixture _fixture { get; set; }
        private readonly AuthenticationParameters _parameters;
        private TokenService _service;

        public TokenServiceTests()
        {
            _fixture = new Fixture();
            _fixture.Customize(new MvcCostumization());

            FixtureAutoMapperConfig.AddMapperFixture(_fixture);

            _parameters = Substitute.For<AuthenticationParameters>();
            _parameters = _fixture.Create<AuthenticationParameters>();
            _fixture.Register(() => _parameters);

            _service = _fixture.Create<TokenService>();
        }

        [Fact]
        private async Task GerarToken_Teste_Sucesso()
        {
            // Arrange
            string usuario = "teste";
            TipoCredencial tipoCredencial = TipoCredencial.Medico;

            // Act
            var resultado = _service.GerarToken(usuario, tipoCredencial);

            // Assert
            Assert.NotNull(resultado);
            Assert.False(string.IsNullOrEmpty(resultado.Token));
        }
    }
}
