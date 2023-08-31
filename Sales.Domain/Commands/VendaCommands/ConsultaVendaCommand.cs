namespace Sales.Domain.Commands.VendaCommands;

public class ConsultaVendaCommand
{
    public Guid Id { get; set; }
    public DateTime DataHora { get;  set; }
    public decimal TotalVenda { get;  set; }
    public decimal TotalPago { get;  set; }
    public decimal Troco { get;  set; }
    public string Status { get;  set; } = string.Empty;

    public List<ConsultaItemVendaCommand> Itens { get; set; } = new List<ConsultaItemVendaCommand>();
}
