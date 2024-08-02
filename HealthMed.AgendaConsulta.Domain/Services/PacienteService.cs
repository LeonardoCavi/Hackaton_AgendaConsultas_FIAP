using HealthMed.AgendaConsulta.Domain.Constants;
using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.Aggregates;
using HealthMed.AgendaConsulta.Domain.Entities.Enums;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;
using HealthMed.AgendaConsulta.Domain.Interfaces.Notifications;
using HealthMed.AgendaConsulta.Domain.Interfaces.Repositories;
using HealthMed.AgendaConsulta.Domain.Interfaces.Services;
using HealthMed.AgendaConsulta.Domain.Interfaces.Vendor;
using HealthMed.AgendaConsulta.Domain.Notifications;
using HealthMed.AgendaConsulta.Domain.Notifications.Abstract;

namespace HealthMed.AgendaConsulta.Domain.Services
{
    public class PacienteService(ITokenService tokenService,
                                 IConsultaRepository consultaRepository,
                                 IPacienteRepository pacienteRepository,
                                 IMedicoRepository medicoRepository,
                                 INotificador notificador, 
                                 IEmailManager emailManager) : NotificadorContext(notificador), IPacienteService
    {
        public async Task<TokenAcesso> Autenticar(Credencial credencial)
        {
            var paciente = await pacienteRepository.Autenticar(credencial);

            if (paciente is null)
            {
                Notificar($"Autenticar: usuário e/ou senha incorretos", TipoNotificacao.Unauthorized);
                return null;
            }

            return tokenService.GerarToken(paciente.Nome, TipoCredencial.Paciente);
        }

        public async Task Cadastrar(Paciente paciente)
        {
            var pacienteDb = await pacienteRepository.ObterPor(x =>
                x.CPF == paciente.CPF ||
                x.Credencial.Email == paciente.Credencial.Email);

            if (pacienteDb.Any())
            {
                Notificar($"Cadastrar: CPF e/ou Email já cadastrados na base", TipoNotificacao.Validation);
                return;
            }

            await pacienteRepository.Inserir(paciente);
        }

        public async Task<List<MedicoHorarioDisponivel>> BuscarMedicos(DateTime dia)
        {
            var medicosHorarioDisponiveis = new List<MedicoHorarioDisponivel>();

            var medicosDb = await medicoRepository.ObterPorDiaTrabalhado(dia.DayOfWeek);

            if (!medicosDb.Any())
            {
                Notificar($"BuscarMedicos: não há médicos disponíveis nesse dia", TipoNotificacao.NotFound);
                return medicosHorarioDisponiveis;
            }

            foreach (var medico in medicosDb)
            {
                var intervalosExpediente = ObtemIntervalosExpediente(dia, medico.HorarioExpediente);
                var diaIntervalosExpediente = intervalosExpediente.Select(x => dia.Date.Add(x.ToTimeSpan()));
                var intervalosSemConsulta = diaIntervalosExpediente.Except(medico.Consultas.Select(x => x.Inicio));

                medicosHorarioDisponiveis.Add(new()
                {
                    Medico = medico,
                    HorariosDisponiveis = intervalosSemConsulta.Select(TimeOnly.FromDateTime).ToList()
                });
            }

            return medicosHorarioDisponiveis;
        }

        public async Task AgendarConsulta(Consulta consulta)
        {
            var medicoDb = await medicoRepository.ObterMedicoConsultasPorId(consulta.MedicoId);
            var pacienteDb = await pacienteRepository.ObterPacienteConsultasPorId(consulta.PacienteId);

            ValidarDisponibilidadeAgendamento(medicoDb, pacienteDb, consulta);

            if (notificador.TemNotificacao())
                return;

            await consultaRepository.Inserir(consulta);

            await emailManager.SendEmailNotification(pacienteDb.Nome, medicoDb.Nome, medicoDb.Credencial.Email, consulta.Inicio);
        }

        private void ValidarDisponibilidadeAgendamento(Medico medico, Paciente paciente, Consulta consulta)
        {
            if (paciente == null)
                Notificar($"AgendarConsulta: paciente não encontrado", TipoNotificacao.Validation);
            else if (paciente.Consultas.Any(x => x.Inicio == consulta.Inicio))
                Notificar($"AgendarConsulta: paciente já possui uma consulta agendada nesse horário", TipoNotificacao.Validation);
            else if (medico == null)
                Notificar($"AgendarConsulta: médico não encontrado", TipoNotificacao.Validation);
            else
            {
                var intervalosExpediente = ObtemIntervalosExpediente(consulta.Inicio, medico.HorarioExpediente);

                if (medico.Consultas.Any(x => x.Inicio == consulta.Inicio))
                    Notificar($"AgendarConsulta: médico já possui uma consulta agendada nesse horário", TipoNotificacao.Validation);

                else if (!intervalosExpediente.Any(x => x == TimeOnly.FromDateTime(consulta.Inicio)))
                    Notificar($"AgendarConsulta: horário de início selecionado é inválido e não se encaixa na agenda do médico", TipoNotificacao.Validation);
            }
        }

        private List<TimeOnly> ObtemIntervalosExpediente(DateTime dia, HorarioExpediente horarioExpediente)
        {
            var intervalos = dia.DayOfWeek switch
            {
                DayOfWeek.Saturday => Enumerable.Range(0, ((int)(horarioExpediente.FimSabado - horarioExpediente.InicioSabado).TotalMinutes / ConsultaConstants.TempoConsultaEmMinutos) + 1)
                                  .Select(i => horarioExpediente.InicioSabado.AddMinutes(i * ConsultaConstants.TempoConsultaEmMinutos)).ToList(),
                DayOfWeek.Monday => Enumerable.Range(0, ((int)(horarioExpediente.FimSegunda - horarioExpediente.InicioSegunda).TotalMinutes / ConsultaConstants.TempoConsultaEmMinutos) + 1)
                                  .Select(i => horarioExpediente.InicioSegunda.AddMinutes(i * ConsultaConstants.TempoConsultaEmMinutos)).ToList(),
                DayOfWeek.Tuesday => Enumerable.Range(0, ((int)(horarioExpediente.FimTerca - horarioExpediente.InicioTerca).TotalMinutes / ConsultaConstants.TempoConsultaEmMinutos) + 1)
                                  .Select(i => horarioExpediente.InicioTerca.AddMinutes(i * ConsultaConstants.TempoConsultaEmMinutos)).ToList(),
                DayOfWeek.Wednesday => Enumerable.Range(0, ((int)(horarioExpediente.FimQuarta - horarioExpediente.InicioQuarta).TotalMinutes / ConsultaConstants.TempoConsultaEmMinutos) + 1)
                                  .Select(i => horarioExpediente.InicioQuarta.AddMinutes(i * ConsultaConstants.TempoConsultaEmMinutos)).ToList(),
                DayOfWeek.Thursday => Enumerable.Range(0, ((int)(horarioExpediente.FimQuinta - horarioExpediente.InicioQuinta).TotalMinutes / ConsultaConstants.TempoConsultaEmMinutos) + 1)
                                  .Select(i => horarioExpediente.InicioQuinta.AddMinutes(i * ConsultaConstants.TempoConsultaEmMinutos)).ToList(),
                DayOfWeek.Friday => Enumerable.Range(0, ((int)(horarioExpediente.FimSexta - horarioExpediente.InicioSexta).TotalMinutes / ConsultaConstants.TempoConsultaEmMinutos) + 1)
                                  .Select(i => horarioExpediente.InicioSexta.AddMinutes(i * ConsultaConstants.TempoConsultaEmMinutos)).ToList(),
                DayOfWeek.Sunday => Enumerable.Range(0, ((int)(horarioExpediente.FimDomingo - horarioExpediente.InicioDomingo).TotalMinutes / ConsultaConstants.TempoConsultaEmMinutos) + 1)
                                   .Select(i => horarioExpediente.InicioDomingo.AddMinutes(i * ConsultaConstants.TempoConsultaEmMinutos)).ToList(),
                _ => new List<TimeOnly>()
            };

            intervalos.Remove(intervalos.Last());

            return intervalos;
        }
    }
}
