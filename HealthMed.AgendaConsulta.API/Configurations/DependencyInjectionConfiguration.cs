using HealthMed.AgendaConsulta.Application.Services;
using HealthMed.AgendaConsulta.Application.Services.Interface;
using HealthMed.AgendaConsulta.Domain.Interfaces.Notifications;
using HealthMed.AgendaConsulta.Domain.Interfaces.Repositories;
using HealthMed.AgendaConsulta.Domain.Interfaces.Services;
using HealthMed.AgendaConsulta.Domain.Interfaces.Vendor;
using HealthMed.AgendaConsulta.Domain.Notifications;
using HealthMed.AgendaConsulta.Domain.Services;
using HealthMed.AgendaConsulta.Infra.Repositories;
using HealthMed.AgendaConsulta.Infra.Vendor;
using System.Diagnostics.CodeAnalysis;

namespace HealthMed.AgendaConsulta.API.Configurations
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            //Vendor
            services.AddScoped<IEmailManager, EmailManager>();

            //Repositories
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<IConsultaRepository, ConsultaRepository>();

            //Services
            services.AddScoped<IMedicoService, MedicoService>();
            services.AddScoped<IPacienteService, PacienteService>();
            services.AddScoped<ITokenService, TokenService>();

            //Application Services
            services.AddScoped<IMedicoApplicationService, MedicoApplicationService>();
            services.AddScoped<IPacienteApplicationService, PacienteApplicationService>();

            //Notificador
            services.AddScoped<INotificador, Notificador>();
        }
    }
}
