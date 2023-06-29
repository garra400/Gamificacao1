using System;
using System.Collections.Generic;
using System.Linq;
using gamificacao1.UI;
using gamificacao1.Models;

namespace gamificacao1.Models;

public class Venda
{
    private int id;
    private Cliente cliente;
    private List<ItemVenda> itensVenda = new List<ItemVenda>();

    public Venda(int id, Cliente cliente)
    {
        this.id = id;
        this.cliente = cliente;
    }

    public int Id { get => id; set => id = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public Produto produto { get => produto; set => produto = value; }
    public List<ItemVenda> ItensVenda { get => itensVenda; set => itensVenda = value; }

    public decimal CalcularValorTotal()
    {
        decimal valorTotal = 0;
        foreach (ItemVenda item in itensVenda)
        {
            valorTotal += item.CalcularSubtotal();
        }
        return valorTotal;
    }
}