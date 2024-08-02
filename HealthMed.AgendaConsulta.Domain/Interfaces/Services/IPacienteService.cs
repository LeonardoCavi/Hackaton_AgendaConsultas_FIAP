using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.Aggregates;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;

namespace HealthMed.AgendaConsulta.Domain.Interfaces.Services
{
    public interface IPacienteService
    {
        Task<TokenAcesso> Autenticar(Credencial credencial);
        Task Cadastrar(Paciente paciente);
        Task<List<MedicoHorarioDisponivel>> BuscarMedicos(DateTime dia);
        Task AgendarConsulta(Consulta consulta);
    }
}
