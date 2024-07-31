using HealthMed.AgendaConsulta.Infra.Vendor.Entities;
using System.Diagnostics.CodeAnalysis;

namespace HealthMed.AgendaConsulta.API.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ParametersConfiguration
    {
        public static void AddParameters(this IServiceCollection services,
                                         IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetRequiredSection("AzureCommunicationService").Get<AzureComunicationServiceParameters>());
        }
    }
}
