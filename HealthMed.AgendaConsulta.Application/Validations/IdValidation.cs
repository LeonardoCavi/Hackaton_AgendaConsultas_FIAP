using FluentValidation;

namespace HealthMed.AgendaConsulta.Application.Validations
{
    public class IdValidation : AbstractValidator<int>
    {
        public IdValidation()
        {
            RuleFor(i => i)
                .GreaterThan(0).WithMessage("Id: o Id precisa ser maior do que zero");
        }
    }
}
