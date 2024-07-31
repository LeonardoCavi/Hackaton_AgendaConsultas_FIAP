using Microsoft.Extensions.Azure;
using System.Diagnostics.CodeAnalysis;

namespace HealthMed.AgendaConsulta.API.Configurations
{
    [ExcludeFromCodeCoverage]
    public static class AzureComunicationServiceConfiguration
    {
        public static void AddAzureComunicationServiceConfiguration(this IServiceCollection services,
                                                                    IConfiguration configuration) 
        {
            var connectionString = configuration
                .GetRequiredSection("AzureCommunicationService")["ConnectionString"] ?? string.Empty;

            services.AddAzureClients(builder =>
            {
                builder.AddEmailClient(connectionString).WithName("MyCommunicationService");
            });
        }
    }
}
