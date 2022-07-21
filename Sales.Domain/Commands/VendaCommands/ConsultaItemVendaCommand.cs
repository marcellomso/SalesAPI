namespace Sales.Domain.Commands.VendaCommands
{
    public class ConsultaItemVendaCommand
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
