using Sales.Domain.Commands;

namespace Sales.Domain.Contracts.Services
{
    public interface IVendaServico : IServiceBase
    {
        Task<int> NovaVendaAsync();
        Task<int?> AdicionarItemAsync(int id, AdicionarItemComand command);
    }
}
