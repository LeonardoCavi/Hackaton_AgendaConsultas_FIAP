namespace HealthMed.AgendaConsulta.Application.ViewModels.Medico
{
    public class EditaExpedienteViewModel
    {
        public bool TrabalhaDomingo { get; set; }
        public TimeOnly InicioDomingo { get; set; }
        public TimeOnly FimDomingo { get; set; }

        public bool TrabalhaSegunda { get; set; }
        public TimeOnly InicioSegunda { get; set; }
        public TimeOnly FimSegunda { get; set; }

        public bool TrabalhaTerca { get; set; }
        public TimeOnly InicioTerca { get; set; }
        public TimeOnly FimTerca { get; set; }

        public bool TrabalhaQuarta { get; set; }
        public TimeOnly InicioQuarta { get; set; }
        public TimeOnly FimQuarta { get; set; }

        public bool TrabalhaQuinta { get; set; }
        public TimeOnly InicioQuinta { get; set; }
        public TimeOnly FimQuinta { get; set; }

        public bool TrabalhaSexta { get; set; }
        public TimeOnly InicioSexta { get; set; }
        public TimeOnly FimSexta { get; set; }

        public bool TrabalhaSabado { get; set; }
        public TimeOnly InicioSabado { get; set; }
        public TimeOnly FimSabado { get; set; }
    }
}
