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
    public class MedicoService(ITokenService tokenService,
                               IMedicoRepository repository,
                               INotificador notificador) : NotificadorContext(notificador), IMedicoService
    {
        public async Task<TokenAcesso> Autenticar(Credencial credencial)
        {
            var medico = await repository.Autenticar(credencial);

            if (medico is null)
            {
                Notificar($"Autenticar: usuário e/ou senha incorretos", TipoNotificacao.Unauthorized);
                return null;
            }

            return tokenService.GerarToken(medico.Nome, TipoCredencial.Medico);
        }

        public Task Cadastrar(Medico medico)
        {
            throw new NotImplementedException();
        }

        public Task EditarExpediente(int id, HorarioExpediente horarioExpediente)
        {
            throw new NotImplementedException();
        }
    }
}
