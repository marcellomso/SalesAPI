using Sales.Domain.Commands.ProdutoCommand;

namespace Sales.Domain.Contracts.Services;

public interface IProdutoServico : IServiceBase
{
    Task<Guid?> AdicionarAsync(ProdutoCommand command);
    Task<Guid?> AtualizarAsync(Guid id, ProdutoCommand command);
    Task<ConsultaProdutoCommand?> ObterPorIdAsync(Guid id);
    Task<IEnumerable<ConsultaProdutoCommand>> ObterAsync();
    Task<IEnumerable<ConsultaProdutoCommand>> ObterAsync(string descricao);
    Task<Guid?> ExcluirAsync(Guid id);
}
