using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.AgendaConsulta.Application.ViewModels.Medico
{
    public class CadastraMedicoViewModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string NumeroCRM { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
