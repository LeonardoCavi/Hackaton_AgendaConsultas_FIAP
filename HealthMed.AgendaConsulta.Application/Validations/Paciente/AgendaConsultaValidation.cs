using FluentValidation;
using HealthMed.AgendaConsulta.Application.ViewModels.Paciente;

namespace HealthMed.AgendaConsulta.Application.Validations.Paciente
{
    public class AgendaConsultaValidation : AbstractValidator<AgendaConsultaViewModel>
    {
        public AgendaConsultaValidation()
        {
            RuleFor(a => a.InicioConsulta)
                .GreaterThan(DateTime.Now)
                .WithMessage("{PropertyPath}: o campo {PropertyName} não pode ser no passado");

            RuleFor(e => e.MedicoId)
                .GreaterThan(0)
                .WithMessage("{PropertyPath}: o campo {PropertyName} não pode ser menor ou igual a zero");
        }
    }
}
