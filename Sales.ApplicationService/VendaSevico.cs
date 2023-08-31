using Sales.Domain.Commands.VendaCommands;
using Sales.Domain.Contracts.Repositories;
using Sales.Domain.Contracts.Services;
using Sales.Domain.Entities;

namespace Sales.ApplicationService;

public class VendaSevico : BaseService, IVendaServico
{
    private readonly IVendaRepositorio _repositorio;
    private readonly IProdutoRepositorio _produtoRepositorio;
    public VendaSevico(
        IVendaRepositorio repositorio,
        IProdutoRepositorio produtoRepositorio,
        IUnitOfWork uow) : base(uow)
    {
        _repositorio = repositorio;
        _produtoRepositorio = produtoRepositorio;
    }

    public async Task<Guid?> AdicionarItemAsync(Guid id, AdicionarItemComand command)
    {
        ValidarCommandEntrada(command, "Objeto venda inválido");

        var venda = await _repositorio.ObterPorIdAsync(id);
        if (venda == null || !EstaValido())
        {
            AddNotification("Venda", "Venda não encontrada");
            return null; //ECodigoRetorno.OperacaoCancelada.GetHashCode();
        }

        var produto = await _produtoRepositorio.ObterPorIdAsync(command.ProdutoId);

        venda.AdicionarItem(produto, command?.Quantidade ?? 0);
        AddNotifications(venda);

        _repositorio.Atualizar(venda);

        if (await Commit())
            return await Task.FromResult(venda.Id);

        return null; //ECodigoRetorno.OperacaoCancelada.GetHashCode();
    }

    public async Task<Guid?> CancelarVendaAsync(Guid id)
    {
        var venda = await _repositorio.ObterAsync(id, true);

        if (venda == null)
        {
            AddNotification("Venda", "Venda não encontrada");
            return null;
        }

        venda.CancelarVenda();
        AddNotifications(venda);
        _repositorio.Atualizar(venda);

        if (await Commit())
            return venda.Id;

        return null;
    }

    public async Task<decimal?> FinalizarVendaAsync(Guid id, decimal valorPago)
    {
        var venda = await _repositorio.ObterPorIdAsync(id);

        if (venda == null)
        {
            AddNotification("Venda", "Venda não encontrada");
            return null;
        }

        venda.FinalizarVenda(valorPago);
        AddNotifications(venda);
        _repositorio.Atualizar(venda);

        if (await Commit())
            return venda.Troco;

        return null;
    }

    public async Task<Guid?> NovaVendaAsync()
    {
        var venda = new Venda();
        AddNotifications(venda.Notifications);

        await _repositorio.AdicionarAsync(venda);

        if (await Commit())
            return await Task.FromResult(venda.Id);

        return null;
    }

    public async Task<ConsultaVendaCommand?> ObterPorIdAsync(Guid id)
    {
        var venda = await _repositorio.ObterAsync(id);

        if (venda == null)
        {
            AddNotification("Venda", "Venda não encontrada");
            return null;
        }

        return new ConsultaVendaCommand()
        {
            Id = venda.Id,
            DataHora = venda.DataHora,
            TotalVenda = venda.TotalVenda,
            TotalPago = venda.TotalPago,
            Troco = venda.Troco,
            Status = venda.Status.ToString(),
            Itens = venda.Itens?.Select(i => new ConsultaItemVendaCommand()
            {
                Id = i.Id,
                ProdutoId = i.ProdutoId,
                Descricao = i.Produto?.Descricao ?? string.Empty,
                PrecoUnitario = i.PrecoUnitario,
                Quantidade = i.Quantidade,
                ValorTotal = i.ValorTotal
            }).ToList() ?? new()
        };
    }
}
