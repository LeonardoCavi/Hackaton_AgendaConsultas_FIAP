using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.Enums;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;
using HealthMed.AgendaConsulta.Domain.Interfaces.Notifications;
using HealthMed.AgendaConsulta.Domain.Interfaces.Repositories;
using HealthMed.AgendaConsulta.Domain.Interfaces.Services;
using HealthMed.AgendaConsulta.Domain.Notifications;
using HealthMed.AgendaConsulta.Domain.Notifications.Abstract;

namespace HealthMed.AgendaConsulta.Domain.Services
{
    public class PacienteService(ITokenService tokenService,
                                 IPacienteRepository repository,
                                 INotificador notificador) : NotificadorContext(notificador), IPacienteService
    {
        public async Task<TokenAcesso> Autenticar(Credencial credencial)
        {
            var paciente = await repository.Autenticar(credencial);

            if (paciente is null)
            {
                Notificar($"Autenticar: usuário e/ou senha incorretos", TipoNotificacao.Unauthorized);
                return null;
            }

            return tokenService.GerarToken(paciente.Nome, TipoCredencial.Paciente);
        }

        public Task<string> AgendarConsulta(Consulta consulta)
        {
            throw new NotImplementedException();
        }

        public Task<object> BuscarMedicos(DateTime inicio, DateTime fim)
        {
            throw new NotImplementedException();
        }

        public Task Cadastrar(Paciente paciente)
        {
            throw new NotImplementedException();
        }
    }
}
