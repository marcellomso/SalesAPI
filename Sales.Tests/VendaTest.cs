using Sales.Domain.Entities;

namespace Sales.Tests
{
    public class VendaTest
    {
        private readonly Produto _produto;
        private readonly decimal _quantidade;
        public VendaTest()
        {
            _quantidade = 1;
            _produto = new Produto("Produto Valido", 1, _quantidade);
        }

        [Test]
        public void AdicionarItemVendaNaoAberta()
        {
            var venda = new Venda();
            venda.FecharVenda();

            venda.AdicionarItem(_produto, _quantidade);

            Assert.That(venda.IsValid, Is.False);
        }
    }
}
