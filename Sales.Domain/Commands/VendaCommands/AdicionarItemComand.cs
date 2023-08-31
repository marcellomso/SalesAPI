namespace Sales.Domain.Commands.VendaCommands;

public class AdicionarItemComand
{
    public Guid ProdutoId { get; set; }
    public decimal Quantidade { get; set; }
}
