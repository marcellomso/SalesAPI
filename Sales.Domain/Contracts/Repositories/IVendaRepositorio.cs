using Sales.Domain.Entities;

namespace Sales.Domain.Contracts.Repositories
{
    public interface IVendaRepositorio
    {
        Task<Venda?> ObterPorIdAsync(int id);
        Task AdicionarAsync(Venda entidade);
        void Atualizar(Venda entidade);
    }
}
