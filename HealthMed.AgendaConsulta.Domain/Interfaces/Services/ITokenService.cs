using HealthMed.AgendaConsulta.Domain.Entities.Enums;
using HealthMed.AgendaConsulta.Domain.Entities.ValueObject;

namespace HealthMed.AgendaConsulta.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        TokenAcesso GerarToken(string usuario, TipoCredencial tipoCredencial);
    }
}
