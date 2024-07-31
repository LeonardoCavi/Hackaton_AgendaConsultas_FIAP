using FluentValidation;
using HealthMed.AgendaConsulta.Application.ViewModels;

namespace HealthMed.AgendaConsulta.Application.Validations
{
    public class AutenticacaoValidation : AbstractValidator<AutenticacaoViewModel>
    {
        public AutenticacaoValidation()
        {
            RuleFor(a => a.Email)
                .NotEmpty().WithMessage("{PropertyPath}: por favor, preencha o campo {PropertyName}")
                .Length(3, 100).WithMessage("{PropertyPath}: o campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(a => a.Senha)
                .NotEmpty().WithMessage("{PropertyPath}: por favor, preencha o campo {PropertyName}")
                .Length(3, 100).WithMessage("{PropertyPath}: o campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
