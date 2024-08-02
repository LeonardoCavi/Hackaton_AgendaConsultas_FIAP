using HealthMed.AgendaConsulta.Application.ViewModels;
using HealthMed.AgendaConsulta.Application.ViewModels.Paciente;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;

namespace HealthMed.AgendaConsulta.Application.Services.Interface
{
    public interface IPacienteApplicationService
    {
        Task<TokenAcesso> AutenticarPaciente(AutenticacaoViewModel autenticacao);
        Task CadastrarPaciente(CadastraPacienteViewModel medico);
        Task<List<BuscaMedicoViewModel>> BuscarMedicos(DateTime dia);
        Task AgendarConsulta(int id, AgendaConsultaViewModel agendaConsulta);
    }
}
