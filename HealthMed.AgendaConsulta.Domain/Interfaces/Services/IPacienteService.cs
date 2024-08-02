using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;

namespace HealthMed.AgendaConsulta.Domain.Interfaces.Services
{
    public interface IPacienteService
    {
        Task<TokenAcesso> Autenticar(Credencial credencial);
        Task Cadastrar(Paciente paciente);
        Task<object> BuscarMedicos(DateTime dia);
        Task<string> AgendarConsulta(Consulta consulta);
    }
}
