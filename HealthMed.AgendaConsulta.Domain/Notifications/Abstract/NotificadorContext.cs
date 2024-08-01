using FluentValidation;
using FluentValidation.Results;
using HealthMed.AgendaConsulta.Domain.Interfaces.Notifications;

namespace HealthMed.AgendaConsulta.Domain.Notifications.Abstract
{
    public abstract class NotificadorContext(INotificador notificador)
    {
        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem, TipoNotificacao tipo = TipoNotificacao.Validation)
        {
            var notificacao = new Notificacao(mensagem, tipo);

            notificador.AddNotificacao(notificacao);
        }

        protected void ExecutarValidacao<TV, TVM>(TV validacao, TVM viewModel) where TV : AbstractValidator<TVM> where TVM : class
        {
            var validator = validacao.Validate(viewModel);

            Notificar(validator);
        }

        protected void ExecutarValidacao<TV>(TV validacao, int id) where TV : AbstractValidator<int>
        {
            var validator = validacao.Validate(id);

            Notificar(validator);
        }

        protected void ExecutarValidacao<TV>(TV validacao, DateTime dia) where TV : AbstractValidator<DateTime>
        {
            var validator = validacao.Validate(dia);

            Notificar(validator);
        }

        protected void ExecutarValidacao<TV>(TV validacao, (int, int) ids) where TV : AbstractValidator<(int, int)>
        {
            var validator = validacao.Validate(ids);

            Notificar(validator);
        }

        protected void ExecutarValidacao<TV>(TV validacao, (decimal, decimal) geoLocalizacao) where TV : AbstractValidator<(decimal, decimal)>
        {
            var validator = validacao.Validate(geoLocalizacao);

            Notificar(validator);
        }

        protected void ExecutarValidacao<TV>(TV validacao, (DateTime, DateTime) intervalo) where TV : AbstractValidator<(DateTime, DateTime)>
        {
            var validator = validacao.Validate(intervalo);

            Notificar(validator);
        }
    }
}
