using FluentValidation;
using HealthMed.AgendaConsulta.Application.ViewModels.Medico;

namespace HealthMed.AgendaConsulta.Application.Validations.Medico
{
    public class EditaExpedienteValidation : AbstractValidator<EditaExpedienteViewModel>
    {
        public EditaExpedienteValidation()
        {
            RuleFor(e => e.InicioDomingo)
                .GreaterThan(e => e.FimDomingo)
                .WithMessage("{PropertyPath}: o campo {PropertyName} não pode ser maior que o campo {ComparisonProperty}");

            RuleFor(e => e.InicioSegunda)
                .GreaterThan(e => e.FimSegunda)
                .WithMessage("{PropertyPath}: o campo {PropertyName} não pode ser maior que o campo {ComparisonProperty}");

            RuleFor(e => e.InicioTerca)
                .GreaterThan(e => e.FimTerca)
                .WithMessage("{PropertyPath}: o campo {PropertyName} não pode ser maior que o campo {ComparisonProperty}");

            RuleFor(e => e.InicioQuarta)
                .GreaterThan(e => e.FimQuarta)
                .WithMessage("{PropertyPath}: o campo {PropertyName} não pode ser maior que o campo {ComparisonProperty}");

            RuleFor(e => e.InicioQuinta)
                .GreaterThan(e => e.FimQuinta)
                .WithMessage("{PropertyPath}: o campo {PropertyName} não pode ser maior que o campo {ComparisonProperty}");

            RuleFor(e => e.InicioSexta)
                .GreaterThan(e => e.FimSexta)
                .WithMessage("{PropertyPath}: o campo {PropertyName} não pode ser maior que o campo {ComparisonProperty}");

            RuleFor(e => e.InicioSabado)
                .GreaterThan(e => e.FimSabado)
                .WithMessage("{PropertyPath}: o campo {PropertyName} não pode ser maior que o campo {ComparisonProperty}");
        }
    }
}
