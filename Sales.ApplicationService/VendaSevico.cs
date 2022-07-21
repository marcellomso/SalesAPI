using Sales.Domain.Commands.VendaCommands;
using Sales.Domain.Contracts.Repositories;
using Sales.Domain.Contracts.Services;
using Sales.Domain.Entities;
using Sales.Domain.Enuns;

namespace Sales.ApplicationService
{
    public class VendaSevico : ServicoBase, IVendaServico
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

        public async Task<int?> AdicionarItemAsync(int id, AdicionarItemComand command)
        {
            ValidarCommandEntrada(command, "Objeto venda inválido");

            var venda = await _repositorio.ObterPorIdAsync(id);
            if (venda == null || !EstaValido())
            {
                AddNotification("Venda", "Venda não encontrada");
                return ECodigoRetorno.OperacaoCancelada.GetHashCode();
            }

            var produto = await _produtoRepositorio.ObterPorIdAsync(command?.ProdutoId ?? 0);

            venda.AdicionarItem(produto, command?.Quantidade ?? 0);
            AddNotifications(venda);

            _repositorio.Atualizar(venda);

            if (await Commit())
                return await Task.FromResult(venda.Id);

            return ECodigoRetorno.OperacaoCancelada.GetHashCode();
        }

        public async Task<int> NovaVendaAsync()
        {
            var venda = new Venda();
            AddNotifications(venda.Notifications);

            await _repositorio.AdicionarAsync(venda);

            if (await Commit())
                return await Task.FromResult(venda.Id);

            return ECodigoRetorno.OperacaoCancelada.GetHashCode();
        }

        public async Task<ConsultaVendaCommand?> ObterPorIdAsync(int id)
        {
            var venda = await _repositorio.ObterPorIdAsync(id);

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
                    Descricao = i.Produto?.Descricao ?? string.Empty,
                    PrecoUnitario = i.PrecoUnitario,
                    Quantidade = i.Quantidade,
                    ValorTotal = i.ValorTotal
                }).ToList() ?? new()
            };
        }
    }
}
