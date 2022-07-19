using Sales.Domain.Enuns;

namespace Sales.Domain.Entities
{
    public class Venda: EntidadeBase
    {
        public DateTime DataHora { get; private set; }
        public List<Item> Itens { get; private set; }
        public decimal TotalVenda { get; private set; }
        public decimal TotalPago { get; private set; }
        public decimal Troco { get; private set; }
        public EStatusVenda Status { get; private set; }

        public Venda()
        {
            DataHora = DateTime.Now;
            Itens = new List<Item>();
            Status = EStatusVenda.Aberta;
        }
    }
}
