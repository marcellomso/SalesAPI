using Flunt.Notifications;
using Sales.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.ApplicationService
{
    public abstract class ServicoBase : Notifiable<Notification>
    {
        private readonly IUnitOfWork _uow;

        public ServicoBase(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public bool Commit()
        {
            if (!IsValid)
                return false;

            _uow.CommitAsync();
            return true;
        }
    }
}
