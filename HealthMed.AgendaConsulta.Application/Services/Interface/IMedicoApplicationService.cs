using HealthMed.AgendaConsulta.Application.ViewModels;
using HealthMed.AgendaConsulta.Application.ViewModels.Medico;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;

namespace HealthMed.AgendaConsulta.Application.Services.Interface
{
    public interface IMedicoApplicationService
    {
        Task<TokenAcesso> AutenticarMedico(AutenticacaoViewModel autenticacao);
        Task CadastrarMedico(CadastraMedicoViewModel medico);
        Task EditarExpediente(int id, EditaExpedienteViewModel expediente);
    }
}
