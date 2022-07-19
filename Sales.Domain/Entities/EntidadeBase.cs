using Flunt.Notifications;

namespace Sales.Domain.Entities
{
    public abstract class EntidadeBase : Notifiable<Notification>
    {
        public int Id { get; private set; }
    }
}
