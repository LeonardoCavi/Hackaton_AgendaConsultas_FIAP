using System.Diagnostics.CodeAnalysis;

namespace HealthMed.AgendaConsulta.Infra.Vendor.Entities
{
    [ExcludeFromCodeCoverage]
    public class AzureComunicationServiceParameters
    {
        public string ConnectionString { get; set; }
        public string Email { get; set; }
    }
}