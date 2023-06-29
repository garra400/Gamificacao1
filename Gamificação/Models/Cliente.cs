using System;
using System.Collections.Generic;
using System.Linq;
using gamificacao1.UI;
using gamificacao1.Models;

namespace gamificacao1.Models;

public class Cliente
{
    private int id;
    private string nome;
    private string email;

    public Cliente(int id, string nome, string email)
    {
        this.id = id;
        this.nome = nome;
        this.email = email;
    }

    public int Id { get => id; set => id = value; }
    public string Nome { get => nome; set => nome = value; }
    public string Email { get => email; set => email = value; }
}