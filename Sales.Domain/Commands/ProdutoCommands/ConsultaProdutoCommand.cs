namespace Sales.Domain.Commands.ProdutoCommand;

public class ConsultaProdutoCommand
{
    public Guid Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public decimal Estoque { get; set; }
    public bool Excluido { get; set; }
}
