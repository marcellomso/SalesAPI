using Sales.Domain.Entities;

namespace Sales.Domain.Contracts.Repositories;

public interface IVendaRepositorio
{
    Task AdicionarAsync(Venda entidade);
    void Atualizar(Venda entidade);
    Task<Venda?> ObterAsync(Guid id, bool isTracking = false);
    Task<Venda?> ObterPorIdAsync(Guid id);
}
