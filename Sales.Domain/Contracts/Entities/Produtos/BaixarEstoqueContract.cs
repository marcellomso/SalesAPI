using Flunt.Validations;
using Sales.Domain.Entities;

namespace Sales.Domain.Contracts.Entities.Produtos;

public class BaixarEstoqueContract : Contract<Produto>
{
    public BaixarEstoqueContract(Produto produto)
        => Requires()
            .IsFalse(produto.Excluido, "Excluido", "Produto excluído, não é permitido alterar o estoque.")
            .IsGreaterOrEqualsThan(produto.Estoque, 0, "Estoque", "Quantidade de itens insuficientes.");
}
