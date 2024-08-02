using AutoFixture;
using AutoMapper;
using HealthMed.AgendaConsulta.API.Mappers;

namespace HealthMed.AgendaConsulta.Test.Fake
{
    internal class FixtureAutoMapperConfig
    {
        private static IMapper _mapper;

        public static void AddMapperFixture(IFixture fixture)
        {
            var config = FixtureMapperConfiguration.InitializeAutoMapper();
            _mapper = config.CreateMapper();
            fixture.Register(() => _mapper);
        }
    }

    internal class FixtureMapperConfiguration
    {

        public static MapperConfiguration InitializeAutoMapper()
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile<MedicoProfile>();
                config.AddProfile<PacienteProfile>();
                config.AddProfile<ErroProfile>();
            });

            return mapper;
        }
    }
}