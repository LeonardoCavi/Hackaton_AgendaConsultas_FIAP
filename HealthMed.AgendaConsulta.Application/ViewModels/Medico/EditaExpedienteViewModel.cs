using System.Diagnostics.CodeAnalysis;

namespace HealthMed.AgendaConsulta.Application.ViewModels.Medico
{
    [ExcludeFromCodeCoverage]
    public class EditaExpedienteViewModel
    {
        public bool TrabalhaDomingo { get; set; }
        public DateTime InicioDomingo { get; set; }
        public DateTime FimDomingo { get; set; }

        public bool TrabalhaSegunda { get; set; }
        public DateTime InicioSegunda { get; set; }
        public DateTime FimSegunda { get; set; }

        public bool TrabalhaTerca { get; set; }
        public DateTime InicioTerca { get; set; }
        public DateTime FimTerca { get; set; }

        public bool TrabalhaQuarta { get; set; }
        public DateTime InicioQuarta { get; set; }
        public DateTime FimQuarta { get; set; }

        public bool TrabalhaQuinta { get; set; }
        public DateTime InicioQuinta { get; set; }
        public DateTime FimQuinta { get; set; }

        public bool TrabalhaSexta { get; set; }
        public DateTime InicioSexta { get; set; }
        public DateTime FimSexta { get; set; }

        public bool TrabalhaSabado { get; set; }
        public DateTime InicioSabado { get; set; }
        public DateTime FimSabado { get; set; }
    }
}
