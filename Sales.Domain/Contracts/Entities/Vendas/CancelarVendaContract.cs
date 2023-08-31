using Flunt.Validations;
using Sales.Domain.Entities;
using Sales.Domain.Enuns;

namespace Sales.Domain.Contracts.Entities.Vendas;

public class CancelarVendaContract : Contract<Venda>
{
    public CancelarVendaContract(Venda venda)
        => Requires()
            .IsTrue(venda.Status == EStatusVenda.Aberta, "Status", "Apenas vendas abertas podem ser canceladas.");
}
