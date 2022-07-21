using Sales.Domain.Entities;

namespace Sales.Domain.Contracts.Repositories
{
    public interface IVendaRepositorio
    {
        Task AdicionarAsync(Venda entidade);
        void Atualizar(Venda entidade);
        Task<Venda?> ObterAsync(int id);
        Task<Venda?> ObterPorIdAsync(int id);
    }
}
