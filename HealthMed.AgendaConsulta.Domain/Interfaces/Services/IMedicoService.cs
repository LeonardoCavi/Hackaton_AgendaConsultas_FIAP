using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;

namespace HealthMed.AgendaConsulta.Domain.Interfaces.Services
{
    public interface IMedicoService
    {
        Task<TokenAcesso> Autenticar(Credencial credencial);
        Task Cadastrar(Medico medico);
        Task EditarExpediente(int id, HorarioExpediente horarioExpediente);
    }
}
