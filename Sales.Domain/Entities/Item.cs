using Sales.Domain.Contracts.Entities.Itens;

namespace Sales.Domain.Entities;

public class Item : BaseEntity
{
    public Guid VendaId { get; private set; }
    public Venda? Venda { get; private set; }
    public Guid ProdutoId { get; private set; }
    public Produto? Produto { get; private set; }
    public decimal Quantidade { get; private set; }
    public decimal PrecoUnitario { get; private set; }
    public decimal ValorTotal
    {
        get
        {
            return Quantidade * PrecoUnitario;
        }
    }

    protected Item() { }

    public Item(Guid vendaId, Produto? produto, decimal quantidade)
    {
        VendaId = vendaId;
        Quantidade = quantidade;
        Produto = produto;

        AddNotifications(new AdicionarProdutoContract(this));

        if (!IsValid)
            return;

        PrecoUnitario = produto?.Preco ?? 0;

        Produto?.BaixarEstoque(quantidade);
        AddNotifications(produto);
    }
}
