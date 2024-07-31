using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.AgendaConsulta.Domain.Entities.ValueObject
{
    public class TokenAcesso
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
