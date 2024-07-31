using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.AgendaConsulta.Domain.Entities.Parameters
{
    public class AuthenticationParameters
    {
        public string SecretKey { get; set; }
        public int ExpiresInHours { get; set; }
    }
}
