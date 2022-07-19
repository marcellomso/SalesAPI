using Sales.Domain.Commands.ProdutoCommand;
using Sales.Domain.Contracts.Repositories;
using Sales.Domain.Contracts.Services;
using Sales.Domain.Entities;


namespace Sales.ApplicationService
{
    public class ProdutoServico : ServicoBase, IProdutoServico
    {
        private readonly IProdutoRepositorio _repositorio;

        public ProdutoServico(
            IProdutoRepositorio repositorio,
            IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repositorio = repositorio;
        }

        public Task<int> AdicionarAsync(NovoProdutoCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<int> AtualizarAsync(NovoProdutoCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExcluirAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Produto>> ObterAsync()
        {
            var produtos = await _repositorio.ObterAsync();
            produtos.Select

        }

        public async Task<Produto?> ObterPorIdAsync(int id)
            => await _repositorio.ObterPorIdAsync(id);

    }
}