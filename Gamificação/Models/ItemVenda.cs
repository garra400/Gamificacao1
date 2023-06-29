using System;
using System.Collections.Generic;
using System.Linq;
using gamificacao1.UI;
using gamificacao1.Models;

namespace gamificacao1.Models;

public class ItemVenda
{
    private Produto produto;
    private int quantidade;

    public ItemVenda(Produto produto, int quantidade)
    {
        this.produto = produto;
        this.quantidade = quantidade;
    }

    public Produto Produto { get => produto; set => produto = value; }
    public int Quantidade { get => quantidade; set => quantidade = value; }

    public decimal CalcularSubtotal()
    {
        return produto.Preco * quantidade;
    }
}