using AutoMapper;
using HealthMed.AgendaConsulta.Application.ViewModels;
using HealthMed.AgendaConsulta.Application.ViewModels.Medico;
using HealthMed.AgendaConsulta.Domain.Entities;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;
using System.Diagnostics.CodeAnalysis;

namespace HealthMed.AgendaConsulta.API.Mappers
{
    [ExcludeFromCodeCoverage]
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
                })
                .AfterMap((src, dest) => dest.HorarioExpediente = new()
                {
                    TrabalhaSabado = false,
                    TrabalhaDomingo = false,

                    TrabalhaSegunda = true,
                    InicioSegunda = new TimeOnly(8, 0),
                    FimSegunda = new TimeOnly(17, 0),

                    TrabalhaTerca = true,
                    InicioTerca = new TimeOnly(8, 0),
                    FimTerca = new TimeOnly(17, 0),

                    TrabalhaQuarta = true,
                    InicioQuarta = new TimeOnly(8, 0),
                    FimQuarta = new TimeOnly(17, 0),

                    TrabalhaQuinta = true,
                    InicioQuinta = new TimeOnly(8, 0),
                    FimQuinta = new TimeOnly(17, 0),

                    TrabalhaSexta = true,
                    InicioSexta = new TimeOnly(8, 0),
                    FimSexta = new TimeOnly(17, 0),
                });

            CreateMap<EditaExpedienteViewModel, HorarioExpediente>();
        }
    }
}
