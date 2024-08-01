﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.AgendaConsulta.Application.Validations.Paciente
{
    public class BuscaMedicosValidation: AbstractValidator<DateTime>
    {
        public BuscaMedicosValidation()
        {
            RuleFor(dia => dia)
                .GreaterThan(DateTime.MinValue)
                .WithMessage("Dia: a data informada não é uma data válida");
        }
    }
}
