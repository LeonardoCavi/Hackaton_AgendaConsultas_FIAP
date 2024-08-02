using HealthMed.AgendaConsulta.Domain.Notifications;

namespace HealthMed.AgendaConsulta.Domain.Interfaces.Notifications
{
    public interface INotificador
    {
        IReadOnlyCollection<Notificacao> ObterNotificacoes();
        bool TemNotificacao();
        void AddNotificacao(Notificacao notificacao);
    }
}
