using HealthMed.AgendaConsulta.Domain.Entities.Parameters;
using System.Diagnostics.CodeAnalysis;

namespace HealthMed.AgendaConsulta.API.Configurations
{
    [ExcludeFromCodeCoverage]
    public static class ParametersConfiguration
    {
        public static void AddParameters(this IServiceCollection services,
                                         IConfiguration configuration)
        {
            services.AddScoped(x => configuration.GetRequiredSection("Authentication").Get<AuthenticationParameters>());
            services.AddScoped(x => configuration.GetRequiredSection("AzureCommunicationService").Get<AzureComunicationServiceParameters>());
        }
    }
}
