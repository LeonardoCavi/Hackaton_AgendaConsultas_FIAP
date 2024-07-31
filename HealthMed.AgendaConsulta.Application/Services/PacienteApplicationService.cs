﻿using AutoMapper;
using HealthMed.AgendaConsulta.Application.Services.Interface;
using HealthMed.AgendaConsulta.Application.Validations;
using HealthMed.AgendaConsulta.Application.Validations.Paciente;
using HealthMed.AgendaConsulta.Application.ViewModels;
using HealthMed.AgendaConsulta.Application.ViewModels.Paciente;
using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;
using HealthMed.AgendaConsulta.Domain.Interfaces.Notifications;
using HealthMed.AgendaConsulta.Domain.Interfaces.Services;
using HealthMed.AgendaConsulta.Domain.Notifications.Abstract;

namespace HealthMed.AgendaConsulta.Application.Services
{
    public class PacienteApplicationServic(IMapper mapper,
                                           IPacienteService service,
                                           INotificador notificador) : NotificadorContext(notificador), IPacienteApplicationService
    {
        public async Task<TokenAcesso> AutenticarPaciente(AutenticacaoViewModel autenticacao)
        {
            ExecutarValidacao(new AutenticacaoValidation(), autenticacao);

            if (!notificador.TemNotificacao())
            {
                var credencialMap = mapper.Map<Credencial>(autenticacao);
                return await service.Autenticar(credencialMap);
            }

            return null;
        }

        public async Task CadastrarPaciente(CadastraPacienteViewModel paciente)
        {
            ExecutarValidacao(new CadastraPacienteValidation(), paciente);

            if (notificador.TemNotificacao())
                return;

            var pacienteMap = mapper.Map<Paciente>(paciente);
            await service.Cadastrar(pacienteMap);
        }

        public async Task<List<BuscaMedicoViewModel>> BuscarMedicos(DateTime inicio, DateTime fim)
        {
            ExecutarValidacao(new BuscaMedicosValidation(), (inicio, fim));

            var medicos = new List<BuscaMedicoViewModel>();

            if (!notificador.TemNotificacao())
            {
                var retorno = await service.BuscarMedicos(inicio, fim);
                medicos.AddRange(mapper.Map<List<BuscaMedicoViewModel>>(retorno));
            }

            return medicos;
        }

        public async Task<string> AgendarConsulta(AgendaConsultaViewModel agendaConsulta)
        {
            ExecutarValidacao(new AgendaConsultaValidation(), agendaConsulta);

            if (!notificador.TemNotificacao())
            {
                var consultaMap = mapper.Map<Consulta>(agendaConsulta);
                return await service.AgendarConsulta(consultaMap);
            }

            return string.Empty;
        }
    }
}
