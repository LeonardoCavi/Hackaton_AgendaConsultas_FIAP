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

        public async Task Cadastrar(Medico medico)
        {
            var medicoDb = await repository.ObterPor(m =>
                m.NumeroCRM == medico.NumeroCRM ||
                m.CPF == medico.CPF ||
                m.Credencial.Email == medico.Credencial.Email);

            if (medicoDb.Count > 0)
            {
                Notificar("CPF e/ou Email e/ou CRM já cadastrados na base.", TipoNotificacao.Validation);
                return;
            }

            await repository.Inserir(medico);
        }

        public async Task EditarExpediente(int id, HorarioExpediente horarioExpediente)
        {
            var medicoDb = await repository.Obter(id);

            if (medicoDb is null)
            {
                Notificar("Médico não cadastrado na base.", TipoNotificacao.Validation);
                return;
            }

            medicoDb.HorarioExpediente = horarioExpediente;
            await repository.Atualizar(medicoDb);
        }
    }
}
