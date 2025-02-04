﻿namespace HealthMed.AgendaConsulta.Domain.Notifications
{
    public enum TipoNotificacao
    {
        Validation,
        NotFound,
        Conflict,
        Unauthorized,
        Error
    }
    public class Notificacao
    {
        public string Mensagem { get; }
        public TipoNotificacao Tipo { get; }
        public Notificacao(string mensagem, TipoNotificacao tipo)
        {
            Mensagem = mensagem;
            Tipo = tipo;
        }
    }
}
