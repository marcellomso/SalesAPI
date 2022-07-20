using Sales.Domain.Commands.ProdutoCommand;
using Sales.Domain.Contracts.Repositories;
using Sales.Domain.Contracts.Services;
using Sales.Domain.Entities;
using Sales.Domain.Enuns;

namespace Sales.ApplicationService
{
    public class ProdutoServico : ServicoBase, IProdutoServico
    {
        private readonly IProdutoRepositorio _repositorio;

        public ProdutoServico(
            IProdutoRepositorio repositorio,
            IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repositorio = repositorio;
        }

        public async Task<int> AdicionarAsync(ProdutoCommand command)
        {
            ValidarCommandEntrada(command, "Objeto produto inválido.");

            if (!EstaValido())
                return ECodigoRetorno.OperacaoCancelada.GetHashCode();

            var produto = new Produto(command.Descricao, command.Preco, command.Estoque);
            AddNotifications(produto.Notifications);

            await _repositorio.AdicionarAsync(produto);

            if (await Commit())
                return await Task.FromResult(produto.Id);

            return ECodigoRetorno.OperacaoCancelada.GetHashCode();
        }

        public async Task<int?> AtualizarAsync(int id, ProdutoCommand command)
        {
            ValidarCommandEntrada(command, "Objeto produto inválido");

            if (!EstaValido())
                return ECodigoRetorno.OperacaoCancelada.GetHashCode();

            var produto = await _repositorio.ObterPorIdAsync(id);

            if (produto == null)
            {
                ProdutoNaoEncontrado();
                return null;
            }

            produto.AlterarProduto(command.Descricao, command.Preco, command.Estoque);
            AddNotifications(produto.Notifications);

            _repositorio.Atualizar(produto);

            if (await Commit())
                return await Task.FromResult(produto.Id);

            return ECodigoRetorno.OperacaoCancelada.GetHashCode();
        }

        public async Task<int?> ExcluirAsync(int id)
        {
            var produto = await _repositorio.ObterPorIdAsync(id);

            if (produto == null)
            {
                ProdutoNaoEncontrado();
                return null;
            }

            produto.Excluir();
            AddNotifications(produto.Notifications);

            _repositorio.Atualizar(produto);

            if (await Commit())
                return produto.Id;

            return ECodigoRetorno.OperacaoCancelada.GetHashCode();
        }

        private void ProdutoNaoEncontrado()
        {
            AddNotification("Produto", "Produto não encontrado");
        }

        private static IEnumerable<ConsultaProdutoCommand> MapearObjetoRetorno(IEnumerable<Produto> produtos)
        {
            return produtos
                .Select(x => new ConsultaProdutoCommand()
                {
                    Id = x.Id,
                    Descricao = x.Descricao,
                    Preco = x.Preco,
                    Estoque = x.Estoque,
                    Excluido = x.Excluido
                }).ToList();
        }

        public async Task<IEnumerable<ConsultaProdutoCommand>> ObterAsync()
        {
            var produtos = await _repositorio.ObterAsync(x => !x.Excluido);
            return MapearObjetoRetorno(produtos);
        }

        public async Task<IEnumerable<ConsultaProdutoCommand>> ObterAsync(string descricao)
        {
            var produtos = await _repositorio.ObterAsync(x => !x.Excluido && x.Descricao.Contains(descricao));
            return MapearObjetoRetorno(produtos);
        }

        public async Task<ConsultaProdutoCommand?> ObterPorIdAsync(int id)
        {
            var produto = await _repositorio.ObterPorIdAsync(id);

            if (produto == null)
            {
                ProdutoNaoEncontrado();
                return null;
            }

            return new ConsultaProdutoCommand()
            {
                Id = produto.Id,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Estoque = produto.Estoque,
                Excluido = produto.Excluido
            };
        }

    }
}