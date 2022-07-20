using Sales.Domain.Entities;

namespace Sales.Tests
{
    public class ProdutoTest
    {
        private readonly Produto produtoExluido;
        public ProdutoTest()
        {
            produtoExluido = new Produto("Produto Valido", 1, 1);
            produtoExluido.Excluir();
        }

        [Test]
        public void ValidarDescricaoPreenchida()
        {
            var produto = new Produto(string.Empty, 1, 1);
            Assert.That(produto.IsValid, Is.False);
        }

        [Test]
        public void ValidarPrecoMaiorZero()
        {
            var produto = new Produto("Produto teste", 0, 1);
            Assert.That(produto.IsValid, Is.False);
        }

        [Test]
        public void ValidarEstoqueMaiorZero()
        {
            var produto = new Produto("Produto teste", 1, 0);
            Assert.That(produto.IsValid, Is.False);
        }

        [Test]
        public void ExcluirProduto()
        {
            produtoExluido.Excluir();

            Assert.That(produtoExluido.IsValid, Is.False);
        }
    }
}