using Sales.Domain.Contracts.Repositories;

namespace Sales.Data.Persistence;

public class UnitOfWork : IUnitOfWork
{
    public readonly SalesDataContext _appContext;

    public UnitOfWork(SalesDataContext appContext)
    {
        _appContext = appContext;
    }

    public async Task CommitAsync()
    {
        await _appContext.SaveChangesAsync();
    }
}
