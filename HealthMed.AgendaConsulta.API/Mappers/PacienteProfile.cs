using AutoMapper;
using HealthMed.AgendaConsulta.Application.ViewModels.Paciente;
using HealthMed.AgendaConsulta.Domain.Constants;
using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.Aggregates;

namespace HealthMed.AgendaConsulta.API.Mappers
{
    public class PacienteProfile : Profile
    {
        public PacienteProfile()
        {
            CreateMap<CadastraPacienteViewModel, Paciente>()
                .AfterMap((src, dest) => dest.Credencial = new()
                {
                    Email = src.Email,
                    Senha = src.Senha
                });

            CreateMap<AgendaConsultaViewModel, Consulta>()
                .AfterMap((src, dest) => dest.Inicio = src.InicioConsulta)
                .AfterMap((src, dest) => dest.Fim = src.InicioConsulta.AddMinutes(ConsultaConstants.TempoConsultaEmMinutos));

            CreateMap<MedicoHorarioDisponivel, BuscaMedicoViewModel>()
                .AfterMap((src, dest) => dest.Id = src.Medico.Id)
                .AfterMap((src, dest) => dest.Nome = src.Medico.Nome)
                .AfterMap((src, dest) => dest.NumeroCRM = src.Medico.NumeroCRM)
                .AfterMap((src, dest) => dest.HorariosDisponiveis = src.HorariosDisponiveis);
        }
    }
}