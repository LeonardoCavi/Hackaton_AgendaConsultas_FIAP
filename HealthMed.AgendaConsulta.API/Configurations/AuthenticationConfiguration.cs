using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace HealthMed.AgendaConsulta.API.Configurations
{
    [ExcludeFromCodeCoverage]
    public static class AutenticationConfiguration
    {
        public static void AddAutenticationConfiguration(this IServiceCollection services,
                                                               IConfiguration configuration)
        {
            var secretKey = configuration
                .GetRequiredSection("Authentication")["SecretKey"] ?? string.Empty;

            var key = Encoding.ASCII.GetBytes(secretKey);

            services.AddAuthentication(a =>
            {
                a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(j =>
            {
                j.RequireHttpsMetadata = false;
                j.SaveToken = true;
                j.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

    }
}
