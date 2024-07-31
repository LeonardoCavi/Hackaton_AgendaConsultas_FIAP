using HealthMed.AgendaConsulta.Domain.Interfaces.Notifications;

namespace HealthMed.AgendaConsulta.Domain.Notifications
{
    public class Notificador : INotificador
    {
        private readonly List<Notificacao> _notificacoes = new List<Notificacao>();

        public void AddNotificacao(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public IReadOnlyCollection<Notificacao> ObterNotificacoes() => _notificacoes;
        public bool TemNotificacao() => _notificacoes.Any();
    }
}
