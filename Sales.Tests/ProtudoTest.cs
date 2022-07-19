using Sales.Domain.Entities;

namespace Sales.Tests
{
    public class ProtudoTest
    {
        [Test]
        public void ValidarDescricaoPreenchida()
        {
            var Produto = new Produto(string.Empty, 1, 1);
            Assert.That(Produto.IsValid, Is.False);
        }

        [Test]
        public void ValidarPrecoMaiorZero()
        {
            var Produto = new Produto("Produto teste", 0, 1);
            Assert.That(Produto.IsValid, Is.False);
        }

        [Test]
        public void ValidarEstoqueMaiorZero()
        {
            var Produto = new Produto("Produto teste", 1, 0);
            Assert.That(Produto.IsValid, Is.False);
        }
    }
}