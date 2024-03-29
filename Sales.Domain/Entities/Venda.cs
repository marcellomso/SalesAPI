﻿using Sales.Domain.Contracts.Entities.Vendas;
using Sales.Domain.Enuns;

namespace Sales.Domain.Entities;

public class Venda : BaseEntity
{
    public DateTime DataHora { get; private set; }
    public decimal TotalVenda { get; private set; }
    public decimal TotalPago { get; private set; }
    public decimal Troco { get; private set; }
    public EStatusVenda Status { get; private set; }

#pragma warning disable IDE0044 // Add readonly modifier
    private List<Item> _items = new();
#pragma warning restore IDE0044 // Add readonly modifier
    public IReadOnlyList<Item> Itens { get { return _items; } }

    public Venda()
    {
        DataHora = DateTime.Now;
        Status = EStatusVenda.Aberta;
    }

    public void AdicionarItem(Produto? produto, decimal quantidade)
    {
        AddNotifications(new AdicionarItemVendaContract(this));

        var item = new Item(Id, produto, quantidade);
        AddNotifications(item);

        _items.Add(item);
        TotalVenda += item.ValorTotal;
    }

    public void FinalizarVenda(decimal totalPago)
    {
        TotalPago = totalPago;

        AddNotifications(new FinalizarVendaContract(this));

        if (!IsValid)
            return;

        Status = EStatusVenda.Finalizada;
        Troco = TotalPago - TotalVenda;
    }

    public void CancelarVenda()
    {
        AddNotifications(new CancelarVendaContract(this));

        if (!IsValid)
            return;

        Status = EStatusVenda.Cancelada;

        foreach (var item in Itens)
            item.Produto?.EstornarEstoque(item.Quantidade);
    }
}
