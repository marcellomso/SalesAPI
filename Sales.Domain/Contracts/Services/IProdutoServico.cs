using Sales.Domain.Commands.ProdutoCommand;

namespace Sales.Domain.Contracts.Services
{
    public interface IProdutoServico: IServiceBase
    {
        Task<int> AdicionarAsync(ProdutoCommand command);
        Task<int?> AtualizarAsync(int id, ProdutoCommand command);
        Task<ConsultaProdutoCommand?> ObterPorIdAsync(int id);
        Task<IEnumerable<ConsultaProdutoCommand>> ObterAsync();
        Task<IEnumerable<ConsultaProdutoCommand>> ObterAsync(string descricao);
        Task<int?> ExcluirAsync(int id);
    }
}
