using Microsoft.EntityFrameworkCore;
using Sales.Data.Persistence;
using Sales.Domain.Contracts.Repositories;
using Sales.Domain.Entities;
using System.Linq.Expressions;

namespace Sales.Data.Repositories
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : EntidadeBase
    {
        public readonly DbSet<TEntity> _dbSet;
        public readonly SalesDataContext _appContext;

        public RepositorioBase(SalesDataContext appContext)
        {
            _dbSet = appContext.Set<TEntity>();
            _appContext = appContext;
        }

        public async Task<IEnumerable<TEntity>> ObterAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            var query = _dbSet.AsQueryable();

            if (filter != null)
                query = query
                    .Where(filter);

            return await query.AsNoTracking().ToListAsync();
        }

        public IQueryable<TEntity> MontarQuery(Expression<Func<TEntity, bool>>? filter = null, bool isTracking = false)
        {
            var query = _dbSet.AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            if (!isTracking)
                query = query.AsNoTracking();

            return query;
        }

        public async Task<TEntity?> ObterPorIdAsync(int id)
            => await _dbSet.FindAsync(id);     

        public async Task AdicionarAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Atualizar(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
