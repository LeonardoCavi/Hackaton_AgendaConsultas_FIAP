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
                Notificar("Cadastrar: CPF e/ou Email e/ou CRM já cadastrados na base.", TipoNotificacao.Validation);
                return;
            }

            await repository.Inserir(medico);
        }

        public async Task EditarExpediente(int id, HorarioExpediente horarioExpediente)
        {
            var medicoDb = await repository.ObterMedicoConsultasPorId(id);

            if (medicoDb is null)
            {
                Notificar("EditarExpediente: Médico não cadastrado na base.", TipoNotificacao.Validation);
                return;
            }

            ValidarAlteracaoExpediente(medicoDb, horarioExpediente);

            if (notificador.TemNotificacao())
                return;

            medicoDb.HorarioExpediente = horarioExpediente;
            await repository.Atualizar(medicoDb);
        }

        private void ValidarAlteracaoExpediente(Medico medico, HorarioExpediente horarioExpediente)
        {
            if ((!horarioExpediente.TrabalhaDomingo || horarioExpediente.InicioDomingo != medico.HorarioExpediente.InicioDomingo || horarioExpediente.FimDomingo != medico.HorarioExpediente.FimDomingo)
                && medico.Consultas.Any(x => x.Inicio.DayOfWeek == DayOfWeek.Sunday && x.Inicio >= DateTime.Now))
                Notificar("EditarExpediente: não é permitido alterar o horário expediente do domingo enquanto houverem consultas agendadas", TipoNotificacao.Validation);

            if ((!horarioExpediente.TrabalhaSegunda || horarioExpediente.InicioSegunda != medico.HorarioExpediente.InicioSegunda || horarioExpediente.FimSegunda != medico.HorarioExpediente.FimSegunda)
                && medico.Consultas.Any(x => x.Inicio.DayOfWeek == DayOfWeek.Monday && x.Inicio >= DateTime.Now))
                Notificar("EditarExpediente: não é permitido alterar o horário expediente da segunda-feira enquanto houverem consultas agendadas", TipoNotificacao.Validation);

            if((!horarioExpediente.TrabalhaTerca || horarioExpediente.InicioTerca != medico.HorarioExpediente.InicioTerca || horarioExpediente.FimTerca != medico.HorarioExpediente.FimTerca)
                && medico.Consultas.Any(x => x.Inicio.DayOfWeek == DayOfWeek.Tuesday && x.Inicio >= DateTime.Now))
                Notificar("EditarExpediente: não é permitido alterar o horário expediente da terça-feira enquanto houverem consultas agendadas", TipoNotificacao.Validation);

            if((!horarioExpediente.TrabalhaQuarta || horarioExpediente.InicioQuarta != medico.HorarioExpediente.InicioQuarta || horarioExpediente.FimQuarta != medico.HorarioExpediente.FimQuarta)
                && medico.Consultas.Any(x => x.Inicio.DayOfWeek == DayOfWeek.Wednesday && x.Inicio >= DateTime.Now))
                Notificar("EditarExpediente: não é permitido alterar o horário expediente da quarta-feira enquanto houverem consultas agendadas", TipoNotificacao.Validation);

            if((!horarioExpediente.TrabalhaQuinta || horarioExpediente.InicioQuinta != medico.HorarioExpediente.InicioQuinta || horarioExpediente.FimQuinta != medico.HorarioExpediente.FimQuinta)
                && medico.Consultas.Any(x => x.Inicio.DayOfWeek == DayOfWeek.Thursday && x.Inicio >= DateTime.Now))
                Notificar("EditarExpediente: não é permitido alterar o horário expediente da quinta-feira enquanto houverem consultas agendadas", TipoNotificacao.Validation);

            if((!horarioExpediente.TrabalhaSexta || horarioExpediente.InicioSexta != medico.HorarioExpediente.InicioSexta || horarioExpediente.FimSexta != medico.HorarioExpediente.FimSexta)
                && medico.Consultas.Any(x => x.Inicio.DayOfWeek == DayOfWeek.Friday && x.Inicio >= DateTime.Now))
                Notificar("EditarExpediente: não é permitido alterar o horário expediente da sexta-feira enquanto houverem consultas agendadas", TipoNotificacao.Validation);

            if ((!horarioExpediente.TrabalhaSabado || horarioExpediente.InicioSabado != medico.HorarioExpediente.InicioSabado || horarioExpediente.FimSabado != medico.HorarioExpediente.FimSabado)
                && medico.Consultas.Any(x => x.Inicio.DayOfWeek == DayOfWeek.Saturday && x.Inicio >= DateTime.Now))
                Notificar("EditarExpediente: não é permitido alterar o horário expediente de sábado enquanto houverem consultas agendadas", TipoNotificacao.Validation);
        }
    }
}
