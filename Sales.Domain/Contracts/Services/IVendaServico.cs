using Sales.Domain.Commands.VendaCommands;

namespace Sales.Domain.Contracts.Services
{
    public interface IVendaServico : IServiceBase
    {
        Task<int> NovaVendaAsync();
        Task<int?> AdicionarItemAsync(int id, AdicionarItemComand command);
        Task<int?> CancelarVendaAsync(int id);
        Task<decimal?> FinalizarVendaAsync(int id, decimal valorPago);
        Task<ConsultaVendaCommand?> ObterPorIdAsync(int id);
    }
}
