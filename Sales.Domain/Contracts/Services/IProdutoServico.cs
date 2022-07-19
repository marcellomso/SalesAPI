using Sales.Domain.Commands.ProdutoCommand;
using Sales.Domain.Entities;

namespace Sales.Domain.Contracts.Services
{
    public interface IProdutoServico
    {
        Task<int> AdicionarAsync(NovoProdutoCommand command);
        Task<int> AtualizarAsync(NovoProdutoCommand command);
        Task<Produto> ObterPorIdAsync(int id);
        Task<IEnumerable<Produto>> ObterAsync();
        Task<bool> ExcluirAsync(int id);
    }
}
