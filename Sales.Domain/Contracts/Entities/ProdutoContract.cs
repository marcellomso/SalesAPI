using Flunt.Validations;
using Sales.Domain.Entities;

namespace Sales.Domain.Contracts.Entities
{
    public class ProdutoContract : Contract<Produto>
    {
        public ProdutoContract(Produto produto)
        {
            Requires()
                .IsNotNullOrEmpty(produto.Descricao, "Descricao", "A descrição do produto deve ser informada.")
                .IsGreaterThan(produto.Preco, 0.01, "Preco", "O preço unitário deve ser maior que zero.")
                .IsGreaterThan(produto.Estoque, 0.01, "Estoque", "O preço unitário deve ser maior que zero.");
        }
    }
}
