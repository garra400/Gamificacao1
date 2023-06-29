using System;
using System.Collections.Generic;
using System.Linq;
using gamificacao1.UI;
using gamificacao1.Models;

namespace gamificacao1.Models;

public class Categoria
{
    private int id;
    private string nome;
    private string descricao;

    public Categoria(int id, string nome, string descricao)
    {
        this.id = id;
        this.nome = nome;
        this.descricao = descricao;
    }

    public int Id { get => id; set => id = value; }
    public string Nome { get => nome; set => nome = value; }
    public string Descricao { get => descricao; set => descricao = value; }
}