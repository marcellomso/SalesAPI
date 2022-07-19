namespace Sales.Domain.Commands.ProdutoCommand
{
    public class NovoProdutoCommand
    {
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public decimal Estoque { get; set; }
    }
}
