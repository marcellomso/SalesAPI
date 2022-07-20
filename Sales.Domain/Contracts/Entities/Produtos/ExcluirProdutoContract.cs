using Flunt.Validations;
using Sales.Domain.Entities;

namespace Sales.Domain.Contracts.Entities.Produtos
{
    public class ExcluirProdutoContract : Contract<Produto>
    {
        public ExcluirProdutoContract(Produto produto)
        {
            Requires().IsFalse(produto.Excluido, "Excluido", "Este produto já está excluido.");
        }
    }
}
