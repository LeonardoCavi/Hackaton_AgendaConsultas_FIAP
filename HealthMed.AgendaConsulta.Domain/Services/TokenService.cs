using HealthMed.AgendaConsulta.Domain.Entities.Enums;
using HealthMed.AgendaConsulta.Domain.Entities.Parameters;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;
using HealthMed.AgendaConsulta.Domain.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HealthMed.AgendaConsulta.Domain.Services
{
    public class TokenService(AuthenticationParameters parameter) : ITokenService
    {
        public TokenAcesso GerarToken(string usuario, TipoCredencial tipoCredencial)
        {
            var key = Encoding.ASCII.GetBytes(parameter.SecretKey);
            int expiresIn = parameter.ExpiresInHours;

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario),
                    new Claim(ClaimTypes.Role, tipoCredencial.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(expiresIn),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new()
            {
                Token = tokenHandler.WriteToken(token),
                Expiration = tokenDescriptor.Expires.Value
            };
        }
    }
}
