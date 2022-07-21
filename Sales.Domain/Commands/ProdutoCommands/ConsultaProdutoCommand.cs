namespace Sales.Domain.Commands.ProdutoCommand
{
    public class ConsultaProdutoCommand
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public decimal Estoque { get; set; }
        public bool Excluido { get; set; }
    }
}
