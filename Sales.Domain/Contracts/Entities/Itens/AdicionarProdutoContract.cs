using Flunt.Validations;
using Sales.Domain.Entities;

namespace Sales.Domain.Contracts.Entities.Itens
{
    public class AdicionarProdutoContract : Contract<Item>
    {
        public AdicionarProdutoContract(Item item)
            => Requires()
                .IsNotNull(item.Produto, "Produto", "Produto inválido");
    }
}
