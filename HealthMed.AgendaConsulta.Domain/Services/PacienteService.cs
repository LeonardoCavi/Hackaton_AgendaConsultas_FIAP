using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;
using HealthMed.AgendaConsulta.Domain.Interfaces.Notifications;
using HealthMed.AgendaConsulta.Domain.Interfaces.Repositories;
using HealthMed.AgendaConsulta.Domain.Interfaces.Services;
using HealthMed.AgendaConsulta.Domain.Notifications.Abstract;

namespace HealthMed.AgendaConsulta.Domain.Services
{
    public class PacienteService(IPacienteRepository repository,
                                   INotificador notificador) : NotificadorContext(notificador), IPacienteService
    {
        public Task<string> AgendarConsulta(Consulta consulta)
        {
            throw new NotImplementedException();
        }

        public Task<object> Autenticar(Credencial credencial)
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
