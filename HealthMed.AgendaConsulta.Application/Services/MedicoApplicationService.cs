using AutoMapper;
using HealthMed.AgendaConsulta.Application.Services.Interface;
using HealthMed.AgendaConsulta.Application.Validations;
using HealthMed.AgendaConsulta.Application.Validations.Medico;
using HealthMed.AgendaConsulta.Application.ViewModels;
using HealthMed.AgendaConsulta.Application.ViewModels.Medico;
using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;
using HealthMed.AgendaConsulta.Domain.Interfaces.Notifications;
using HealthMed.AgendaConsulta.Domain.Interfaces.Services;
using HealthMed.AgendaConsulta.Domain.Notifications.Abstract;

namespace HealthMed.AgendaConsulta.Application.Services
{
    public class MedicoApplicationService(IMapper mapper,
                                          IMedicoService service,
                                          INotificador notificador) : NotificadorContext(notificador), IMedicoApplicationService
    {
        public async Task<TokenAcesso> AutenticarMedico(AutenticacaoViewModel autenticacao)
        {
            ExecutarValidacao(new AutenticacaoValidation(), autenticacao);

            if (!notificador.TemNotificacao())
            {
                var credencialMap = mapper.Map<Credencial>(autenticacao);
                return await service.Autenticar(credencialMap);
            }

            return null;
        }

        public async Task CadastrarMedico(CadastraMedicoViewModel medico)
        {
            ExecutarValidacao(new CadastraMedicoValidation(), medico);

            if (notificador.TemNotificacao())
                return;

            var medicoMap = mapper.Map<Medico>(medico);
            await service.Cadastrar(medicoMap);
        }

        public async Task EditarExpediente(int id, EditaExpedienteViewModel expediente)
        {
            ExecutarValidacao(new EditaExpedienteValidation(), expediente);

            if (!notificador.TemNotificacao())
            {
                var horarioExpedienteMap = mapper.Map<HorarioExpediente>(expediente);
                await service.EditarExpediente(id, horarioExpedienteMap);
            }
        }
    }
}
