using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.AgendaConsulta.Domain.Interfaces.Services
{
    public interface IMedicoService
    {
        Task<object> Autenticar(Credencial credencial);
        Task Cadastrar(Medico medico);
        Task EditarExpediente(int id, HorarioExpediente horarioExpediente);
    }
}
