using Sales.Domain.Entities;

namespace Sales.Tests;

public class VendaTest
{
    private readonly Produto _produto;
    private readonly decimal _quantidade;
    private readonly decimal _preco;
    private readonly decimal _totalVenda;

    private Venda _vendaCancelada;
    private Venda _vendaValida;

    public VendaTest()
    {
        _quantidade = 2;
        _preco = 10;
        _totalVenda = _quantidade * _preco;
        _produto = new Produto("Produto Valido", _preco, 2000);
    }

    [SetUp]
    public void IniciarVariaveis()
    {
        _vendaCancelada = new Venda();
        _vendaCancelada.AdicionarItem(_produto, _quantidade);
        _vendaCancelada.CancelarVenda();

        _vendaValida= new Venda();
        _vendaValida.AdicionarItem(_produto, _quantidade);
    }

    [Test]
    public void AdicionarItemVendaNaoAberta()
    {
        _vendaCancelada.AdicionarItem(_produto, _quantidade);
        Assert.That(_vendaCancelada.IsValid, Is.False);
    }

    [Test]
    public void FinalizarVendaNaoAberta()
    {
        _vendaCancelada.FinalizarVenda(_totalVenda);
        Assert.That(_vendaCancelada.IsValid, Is.False);
    }

    [Test]
    public void FinalizarVendaValorPagamentoMenor()
    {
        _vendaValida.FinalizarVenda(_vendaValida.TotalVenda - 1);
        Assert.That(_vendaValida.IsValid, Is.False);
    }

    [Test]
    public void CancelarVendaNaoAberta()
    {
        _vendaCancelada.CancelarVenda();
        Assert.That(_vendaCancelada.IsValid, Is.False);
    }
}
