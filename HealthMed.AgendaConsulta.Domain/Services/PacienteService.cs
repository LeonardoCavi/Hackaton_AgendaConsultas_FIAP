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
                                 IPacienteRepository pacienteRepository,
                                 IMedicoRepository medicoRepository,
                                 INotificador notificador) : NotificadorContext(notificador), IPacienteService
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
                Notificar($"Cadastrar: CPF e/ou Email já cadastrados na base.", TipoNotificacao.Validation);
                return;
            }

            await pacienteRepository.Inserir(paciente);
        }

        public async Task<object> BuscarMedicos(DateTime dia)
        {
            var medicosAptos = new List<Medico>();
            var medicos = await medicoRepository.ObterPorDiaTrabalhado(dia.DayOfWeek);

            var medicosSemConsultas = medicos.Where(x => !x.Consultas.Any());

            var medicosComConsultas = medicos.Where(x => x.Consultas.Any());

            return null;
        }

        public Task<string> AgendarConsulta(Consulta consulta)
        {
            throw new NotImplementedException();
        }
    }
}
