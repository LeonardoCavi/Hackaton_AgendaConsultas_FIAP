using HealthMed.AgendaConsulta.Infra;
using Microsoft.EntityFrameworkCore;

namespace HealthMed.AgendaConsulta.API.Configurations
{
    public static class DbContextConfiguration
    {
        public static void AddDbContextConfiguration(this IServiceCollection services,
                                                     IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString"));
            });
        }
    }
}
