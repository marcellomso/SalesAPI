﻿using Sales.Domain.Entities;
using System.Linq.Expressions;

namespace Sales.Domain.Contracts.Repositories
{
    public interface IRepositorioBase<TEntity> where TEntity : EntidadeBase
    {
        Task<IEnumerable<TEntity>> ObterAsync(Expression<Func<TEntity, bool>>? filter = null);
        IQueryable<TEntity> MontarQuery(Expression<Func<TEntity, bool>>? filter = null, bool isTracking = false);
        Task<TEntity?> ObterPorIdAsync(int id);
        Task AdicionarAsync(TEntity entidade);
        void Atualizar(TEntity entidade);
    }
}
