using Flunt.Validations;
using Sales.Domain.Entities;

namespace Sales.Domain.Contracts.Entities.Vendas
{
    public class FinalizarVendaContract: Contract<Venda>
    {
        public FinalizarVendaContract(Venda venda)
            => Requires()
                .IsTrue(venda.Status == Enuns.EStatusVenda.Aberta, "Status", "Apenas vendas abertas podem ser finalizadas.")
                .IsGreaterOrEqualsThan(venda.TotalPago, venda.TotalVenda, "TotalPago", "Total pago não deve ser menor que o valor total da venda.");
    }
}
