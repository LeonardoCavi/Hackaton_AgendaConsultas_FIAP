using System.Diagnostics.CodeAnalysis;

namespace HealthMed.AgendaConsulta.Application.ViewModels.Medico
{
    [ExcludeFromCodeCoverage]
    public class CadastraMedicoViewModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string NumeroCRM { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}