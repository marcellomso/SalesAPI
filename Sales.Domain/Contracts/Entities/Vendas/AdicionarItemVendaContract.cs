using Flunt.Validations;
using Sales.Domain.Entities;

namespace Sales.Domain.Contracts.Entities.Vendas;

public class AdicionarItemVendaContract : Contract<Venda>
{
    public AdicionarItemVendaContract(Venda venda)
        => Requires()
            .IsTrue(venda.Status == Enuns.EStatusVenda.Aberta, "Status", "A venda não está aberta.");
}
