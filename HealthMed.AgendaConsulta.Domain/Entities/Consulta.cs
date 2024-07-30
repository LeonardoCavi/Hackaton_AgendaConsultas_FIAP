﻿namespace HealthMed.AgendaConsulta.Domain.Entities
{
    public class Consulta : EntidadeBase
    {
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public int MedicoId { get; set; }
        public int PacienteId { get; set; }
    }
}
