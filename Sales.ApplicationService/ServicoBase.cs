using Flunt.Notifications;
using Flunt.Validations;
using Sales.Domain.Contracts.Repositories;
using Sales.Domain.Contracts.Services;

namespace Sales.ApplicationService
{
    public abstract class ServicoBase : Notifiable<Notification>, IServiceBase
    {
        private readonly IUnitOfWork _uow;

        public ServicoBase(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Commit()
        {
            if (IsValid)
            {
                await _uow.CommitAsync();
                return true;
            }

            return false;
        }

        public bool EstaValido() => IsValid;

        public List<string> Notificacoes()
        {
            var lista = new List<string>();
            foreach (var notification in Notifications)
                lista.Add($"{notification.Key} - {notification.Message}");

            return lista;
        }

        public void ValidarCommandEntrada(object command, string mensagemRetorno)
        => AddNotifications(new Contract<ServicoBase>()
                .IsNotNull(command, "Command", mensagemRetorno));
    }
}
