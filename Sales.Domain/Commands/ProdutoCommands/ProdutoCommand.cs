namespace Sales.Domain.Commands.ProdutoCommand
{
    public class ProdutoCommand
    {
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public decimal Estoque { get; set; }
    }
}
