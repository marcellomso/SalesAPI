namespace Sales.Domain.Entities
{
    public class Item : EntidadeBase
    {
        public int ProdutoId { get; private set; }
        public Produto Produto { get; private set; }
        public decimal Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public decimal ValorTotal
        {
            get
            {
                return Quantidade * PrecoUnitario;
            }
        }
    }
}
