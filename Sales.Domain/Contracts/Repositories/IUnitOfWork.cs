namespace Sales.Domain.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
