using Sales.Domain.Contracts.Repositories;
using Sales.Domain.Entities;
using System.Linq.Expressions;

namespace Sales.Data.Repositories
{
    public class ProdutoRepositorio: IProdutoRepositorio
    {
        private readonly IRepositorioBase<Produto> _repositorioBase;

        public ProdutoRepositorio(IRepositorioBase<Produto> repositorioBase)
        {
            _repositorioBase = repositorioBase;
        }

        public async Task AdicionarAsync(Produto entidade)
            => await _repositorioBase.AdicionarAsync(entidade);

        public void Atualizar(Produto entidade)
            => _repositorioBase.Atualizar(entidade);

        public async Task<IEnumerable<Produto>> ObterAsync(Expression<Func<Produto, bool>>? filter = null)
            => await _repositorioBase.ObterAsync(filter);

        public async Task<Produto?> ObterPorIdAsync(int id)
            =>  await _repositorioBase.ObterPorIdAsync(id);
    }
}
