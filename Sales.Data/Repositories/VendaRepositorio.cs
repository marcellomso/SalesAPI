using Microsoft.EntityFrameworkCore;
using Sales.Domain.Contracts.Repositories;
using Sales.Domain.Entities;
using System.Linq.Expressions;

namespace Sales.Data.Repositories
{
    public class VendaRepositorio : IVendaRepositorio
    {
        private IRepositorioBase<Venda> _repositorioBase;

        public VendaRepositorio(IRepositorioBase<Venda> repositorioBase)
        {
            _repositorioBase = repositorioBase;
        }

        public async Task AdicionarAsync(Venda entidade)
            => await _repositorioBase.AdicionarAsync(entidade);

        public void Atualizar(Venda entidade)
            => _repositorioBase.Atualizar(entidade);

        public async Task<Venda?> ObterPorIdAsync(int id)
            => await _repositorioBase
                .MontarQuery(v => v.Id == id)
                .Include(v => v.Itens)
                .ThenInclude(i => i.Produto)
                .FirstOrDefaultAsync();
    }
}
