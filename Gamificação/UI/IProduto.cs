using System;
using System.Collections.Generic;
using System.Linq;
using gamificacao1.Models;

namespace gamificacao1.UI;
public class ProdutoUI
{
    public static void CadastrarProduto(List<Produto> listaProdutos, List<Categoria> listaCategorias)
    {
        Console.Clear();
        Console.WriteLine("CADASTRO DE PRODUTO\n");

        Console.Write("Nome do produto: ");
        string nome = Console.ReadLine();

        Console.Write("Descrição do produto: ");
        string descricao = Console.ReadLine();

        Console.Write("Preço do produto: ");
        decimal preco = decimal.Parse(Console.ReadLine());

        Console.WriteLine("\nSelecione a categoria do produto:");

        CategoriaUI.ListarCategorias(listaCategorias);

        Console.Write("Digite o ID da categoria: ");
        int idCategoria = int.Parse(Console.ReadLine());

        Categoria categoria = listaCategorias.Find(c => c.Id == idCategoria);

        int id = listaProdutos.Count + 1;

        Produto produto = new Produto(id, nome, descricao, categoria, preco);

        listaProdutos.Add(produto);

        Console.WriteLine("\nProduto cadastrado com sucesso!");
    }

    public static void ListarProdutos(List<Produto> listaProdutos)
    {
        Console.Clear();
        Console.WriteLine("LISTAGEM DE PRODUTOS\n");

        foreach (Produto produto in listaProdutos)
        {
            Console.WriteLine("ID: " + produto.Id);
            Console.WriteLine("Nome: " + produto.Nome);
            Console.WriteLine("Descrição: " + produto.Descricao);
            Console.WriteLine("Preço: " + produto.Preco.ToString("C2"));
            Console.WriteLine("Categoria: " + produto.Categoria.Nome);
            Console.WriteLine("--------------------------");
        }
    }
}