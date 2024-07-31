using AutoMapper;
using HealthMed.AgendaConsulta.Application.ViewModels;
using HealthMed.AgendaConsulta.Application.ViewModels.Medico;
using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;

namespace HealthMed.AgendaConsulta.API.Mappers
{
    public class MedicoProfile : Profile
    {
        public MedicoProfile()
        {
            CreateMap<AutenticacaoViewModel, Credencial>();

            CreateMap<CadastraMedicoViewModel, Medico>()
                .AfterMap((src, dest) => dest.Credencial = new()
                {
                    Email = src.Email,
                    Senha = src.Senha,
                });

            CreateMap<EditaExpedienteViewModel, HorarioExpediente>();
        }
    }
}
