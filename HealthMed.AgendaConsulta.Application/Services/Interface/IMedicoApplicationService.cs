using HealthMed.AgendaConsulta.Application.ViewModels;
using HealthMed.AgendaConsulta.Application.ViewModels.Medico;

namespace HealthMed.AgendaConsulta.Application.Services.Interface
{
    public interface IMedicoApplicationService
    {
        Task<object> AutenticarMedico(AutenticacaoViewModel autenticacao);
        Task CadastrarMedico(CadastraMedicoViewModel medico);
        Task EditarExpediente(int id, EditaExpedienteViewModel expediente);
    }
}
