using FluentValidation;
using HealthMed.AgendaConsulta.Application.ViewModels.Medico;

namespace HealthMed.AgendaConsulta.Application.Validations.Medico
{
    public class CadastraMedicoValidation : AbstractValidator<CadastraMedicoViewModel>
    {
        public CadastraMedicoValidation()
        {
            RuleFor(m => m.Nome)
                .NotEmpty().WithMessage("{PropertyPath}: por favor, preencha o campo {PropertyName}")
                .Length(3, 100).WithMessage("{PropertyPath}: o campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(m => m.CPF)
                .NotEmpty().WithMessage("{PropertyPath}: por favor, preencha o campo {PropertyName}")
                .Length(3, 100).WithMessage("{PropertyPath}: o campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(m => m.NumeroCRM)
                .NotEmpty().WithMessage("{PropertyPath}: por favor, preencha o campo {PropertyName}")
                .Length(3, 100).WithMessage("{PropertyPath}: o campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(m => m.Email)
                .NotEmpty().WithMessage("{PropertyPath}: por favor, preencha o campo {PropertyName}")
                .Length(3, 100).WithMessage("{PropertyPath}: o campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(m => m.Senha)
                .NotEmpty().WithMessage("{PropertyPath}: por favor, preencha o campo {PropertyName}")
                .Length(3, 100).WithMessage("{PropertyPath}: o campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
