using System.Diagnostics.CodeAnalysis;

namespace HealthMed.AgendaConsulta.Domain.Entities.ValueObject
{
    [ExcludeFromCodeCoverage]
    public class TokenAcesso
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}