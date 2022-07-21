using Sales.Data.Persistence;
using Sales.Domain.Contracts.Repositories;
using Sales.Domain.Entities;

namespace Sales.Data.Repositories
{
    public class VendaRepositorio : RepositorioBase<Venda>, IVendaRepositorio
    {
        public VendaRepositorio(SalesDataContext appContext) : base(appContext)
        {
        }
    }
}
