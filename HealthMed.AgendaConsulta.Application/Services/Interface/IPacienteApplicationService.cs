using HealthMed.AgendaConsulta.Application.ViewModels;
using HealthMed.AgendaConsulta.Application.ViewModels.Paciente;

namespace HealthMed.AgendaConsulta.Application.Services.Interface
{
    public interface IPacienteApplicationService
    {
        Task<object> AutenticarPaciente(AutenticacaoViewModel autenticacao);
        Task CadastrarPaciente(CadastraPacienteViewModel medico);
        Task<List<BuscaMedicoViewModel>> BuscarMedicos(DateTime inicio, DateTime fim);
        Task<string> AgendarConsulta(AgendaConsultaViewModel agendaConsulta);
    }
}
