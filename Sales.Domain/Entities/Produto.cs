using Sales.Domain.Contracts.Entities;

namespace Sales.Domain.Entities
{
    public class Produto : EntidadeBase
    {
        public string Descricao { get; private set; } = string.Empty;
        public decimal Preco { get; private set; }
        public decimal Estoque { get; private set; }
        public bool Ativo { get; private set; }

        protected Produto() { }

        public Produto(string descricao, decimal precoUnitario, decimal estoque)
        {
            Descricao = descricao;
            Preco = precoUnitario;
            Estoque = estoque;
            Ativo = true;

            AddNotifications(new ProdutoContract(this));
        }

        public void AlterarProduto(string descricao, decimal precoUnitario, decimal estoque)
        {
            AddNotifications(new ProdutoContract(this));

            if (!IsValid)
                return;

            Descricao = descricao;
            Preco = precoUnitario;
            Estoque = estoque;
        }

        public void Excluir()
        {
            Ativo = false;
        }
    }
}
