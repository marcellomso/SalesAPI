using Sales.Domain.Entities;
using System.Linq.Expressions;

namespace Sales.Domain.Contracts.Repositories;

public interface IProdutoRepositorio
{
    Task<IEnumerable<Produto>> ObterAsync(Expression<Func<Produto, bool>>? filter = null);
    Task<Produto?> ObterPorIdAsync(Guid id);
    Task AdicionarAsync(Produto entidade);
    void Atualizar(Produto entidade);
}