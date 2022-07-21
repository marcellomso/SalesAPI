using Sales.Domain.Entities;

namespace Sales.Tests
{
    public class ProdutoTest
    {
        private readonly Produto _produtoExluido;
        public ProdutoTest()
        {
            _produtoExluido = new Produto("Produto Valido", 1, 1);
            _produtoExluido.Excluir();
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
            _produtoExluido.Excluir();

            Assert.That(_produtoExluido.IsValid, Is.False);
        }

        [Test]
        public void BaixarEstoqueNegativo()
        {
            var produto = new Produto("Produto Valido", 1, 1);
            produto.BaixarEstoque(5);

            Assert.That(produto.IsValid, Is.False);
        }
    }
}