using Sales.Data.Persistence;
using Sales.Domain.Contracts.Repositories;
using Sales.Domain.Entities;

namespace Sales.Data.Repositories
{
    public class ProdutoRepositorio: RepositorioBase<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(SalesDataContext appContext) : base(appContext)
        {

        }
    }
}
