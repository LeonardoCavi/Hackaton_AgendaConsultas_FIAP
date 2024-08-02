using System.Diagnostics.CodeAnalysis;

namespace HealthMed.AgendaConsulta.Domain.Entities.Parameters
{
    [ExcludeFromCodeCoverage]
    public class AuthenticationParameters
    {
        public string SecretKey { get; set; }
        public int ExpiresInHours { get; set; }
    }
}