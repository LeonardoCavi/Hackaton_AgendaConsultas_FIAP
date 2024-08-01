using FluentValidation;
using HealthMed.AgendaConsulta.Application.ViewModels.Medico;

namespace HealthMed.AgendaConsulta.Application.Validations.Medico
{
    public class EditaExpedienteValidation : AbstractValidator<EditaExpedienteViewModel>
    {
        public EditaExpedienteValidation()
        {
            RuleFor(e => e.InicioDomingo)
                .LessThan(e => e.FimDomingo)
                .When(e => e.TrabalhaDomingo)
                .WithMessage("{PropertyPath}: o campo {PropertyName} não pode ser maior que o campo {ComparisonProperty}");

            RuleFor(e => e.InicioSegunda)
                .LessThan(e => e.FimSegunda)
                .When(e => e.TrabalhaSegunda)
                .WithMessage("{PropertyPath}: o campo {PropertyName} não pode ser maior que o campo {ComparisonProperty}");

            RuleFor(e => e.InicioTerca)
                .LessThan(e => e.FimTerca)
                .When(e => e.TrabalhaTerca)
                .WithMessage("{PropertyPath}: o campo {PropertyName} não pode ser maior que o campo {ComparisonProperty}");

            RuleFor(e => e.InicioQuarta)
                .LessThan(e => e.FimQuarta)
                .When(e => e.TrabalhaQuarta)
                .WithMessage("{PropertyPath}: o campo {PropertyName} não pode ser maior que o campo {ComparisonProperty}");

            RuleFor(e => e.InicioQuinta)
                .LessThan(e => e.FimQuinta)
                .When(e => e.TrabalhaQuinta)
                .WithMessage("{PropertyPath}: o campo {PropertyName} não pode ser maior que o campo {ComparisonProperty}");

            RuleFor(e => e.InicioSexta)
                .LessThan(e => e.FimSexta)
                .When(e => e.TrabalhaSexta)
                .WithMessage("{PropertyPath}: o campo {PropertyName} não pode ser maior que o campo {ComparisonProperty}");

            RuleFor(e => e.InicioSabado)
                .LessThan(e => e.FimSabado)
                .When(e => e.TrabalhaSabado)
                .WithMessage("{PropertyPath}: o campo {PropertyName} não pode ser maior que o campo {ComparisonProperty}");
        }
    }
}
