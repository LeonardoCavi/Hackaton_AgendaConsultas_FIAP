using System.Diagnostics.CodeAnalysis;

namespace HealthMed.AgendaConsulta.Domain.Entities.ValueObject
{
    [ExcludeFromCodeCoverage]
    public class Credencial
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}