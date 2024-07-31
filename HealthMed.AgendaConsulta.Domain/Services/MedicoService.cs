using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;
using HealthMed.AgendaConsulta.Domain.Interfaces.Notifications;
using HealthMed.AgendaConsulta.Domain.Interfaces.Repositories;
using HealthMed.AgendaConsulta.Domain.Interfaces.Services;
using HealthMed.AgendaConsulta.Domain.Notifications.Abstract;

namespace HealthMed.AgendaConsulta.Domain.Services
{
    public class MedicoService(IMedicoRepository repository,
                                 INotificador notificador) : NotificadorContext(notificador), IMedicoService
    {
        public Task<object> Autenticar(Credencial credencial)
        {
            throw new NotImplementedException();
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
