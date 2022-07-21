using Sales.Domain.Contracts.Entities.Produtos;

namespace Sales.Domain.Entities
{
    public class Produto : EntidadeBase
    {
        public string Descricao { get; private set; } = string.Empty;
        public decimal Preco { get; private set; }
        public decimal Estoque { get; private set; }
        public bool Excluido { get; private set; }

        protected Produto() { }

        public Produto(string descricao, decimal precoUnitario, decimal estoque)
        {
            Descricao = descricao.Trim();
            Preco = precoUnitario;
            Estoque = estoque;

            AddNotifications(new ProdutoContract(this));
        }

        public void AlterarProduto(string descricao, decimal precoUnitario, decimal estoque)
        {
            Descricao = descricao.Trim();
            Preco = precoUnitario;
            Estoque = estoque;

            AddNotifications(new ProdutoContract(this));
        }

        public void Excluir()
        {
            AddNotifications(new ExcluirProdutoContract(this));

            if (IsValid)
                Excluido = true;
        }

        public void BaixarEstoque(decimal quantidade)
        {
            Estoque -= quantidade;

            AddNotifications(new BaixarEstoqueContract(this));
        }

        public void EstornarEstoque(decimal quantidade)
            => Estoque += quantidade;
    }
}
