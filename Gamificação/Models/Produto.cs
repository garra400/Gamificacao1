using System;
using System.Collections.Generic;
using System.Linq;
using gamificacao1.UI;
using gamificacao1.Models;

namespace gamificacao1.Models;

public class Produto
{
    private int id;
    private string nome;
    private string descricao;
    private Categoria categoria;
    private decimal preco;

    public Produto(int id, string nome, string descricao, Categoria categoria, decimal preco)
    {
        this.id = id;
        this.nome = nome;
        this.descricao = descricao;
        this.categoria = categoria;
        this.preco = preco;
    }

    public int Id { get => id; set => id = value; }
    public string Nome { get => nome; set => nome = value; }
    public string Descricao { get => descricao; set => descricao = value; }
    public Categoria Categoria { get => categoria; set => categoria = value; }
    public decimal Preco { get => preco; set => preco = value; }
}