using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.AgendaConsulta.Domain.Interfaces.Services
{
    public interface IPacienteService
    {
        Task<TokenAcesso> Autenticar(Credencial credencial);
        Task Cadastrar(Paciente paciente);
        Task<object> BuscarMedicos(DateTime inicio, DateTime fim);
        Task<string> AgendarConsulta(Consulta consulta);
    }
}
