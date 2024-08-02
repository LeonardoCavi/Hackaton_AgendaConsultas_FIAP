using AutoMapper;
using HealthMed.AgendaConsulta.Application.ViewModels.Paciente;
using HealthMed.AgendaConsulta.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace HealthMed.AgendaConsulta.API.Mappers
{
    [ExcludeFromCodeCoverage]
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

            CreateMap<AgendaConsultaViewModel, Consulta>();
        }
    }
}
