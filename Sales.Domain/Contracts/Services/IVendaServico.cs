using Sales.Domain.Commands.VendaCommands;

namespace Sales.Domain.Contracts.Services;

public interface IVendaServico : IServiceBase
{
    Task<Guid?> NovaVendaAsync();
    Task<Guid?> AdicionarItemAsync(Guid id, AdicionarItemComand command);
    Task<Guid?> CancelarVendaAsync(Guid id);
    Task<decimal?> FinalizarVendaAsync(Guid id, decimal valorPago);
    Task<ConsultaVendaCommand?> ObterPorIdAsync(Guid id);
}
