using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.AgendaConsulta.Application.Validations.Paciente
{
    public class BuscaMedicosValidation: AbstractValidator<(DateTime Inicio, DateTime Fim)>
    {
        public BuscaMedicosValidation()
        {
            RuleFor(busca => busca.Inicio)
                .GreaterThan(busca => busca.Fim)
                .WithMessage("Inicio: o campo Inicio não pode ser maior que o campo Fim");
        }
    }
}
