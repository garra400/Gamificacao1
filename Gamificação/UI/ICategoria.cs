using System;
using System.Collections.Generic;
using System.Linq;
using gamificacao1.Models;

namespace gamificacao1.UI;
public class CategoriaUI
{   
    public static void CadastrarCategoria(List<Categoria> listaCategorias)
        {
            Console.WriteLine("Digite o nome da categoria:");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite a descrição da categoria:");
            string descricao = Console.ReadLine();
            int id = listaCategorias.Count + 1;
            Categoria categoria = new Categoria(id, nome, descricao);
            listaCategorias.Add(categoria);
            Console.WriteLine("Categoria cadastrada com sucesso!");
        }
    public static void ListarCategorias(List<Categoria> listaCategorias)
    {
        Console.WriteLine("Listagem de Categorias");
        Console.WriteLine("----------------------");
        foreach (Categoria categoria in listaCategorias)
        {
            Console.WriteLine("ID: {0}", categoria.Id);
            Console.WriteLine("Nome: {0}", categoria.Nome);
            Console.WriteLine("Descrição: {0}", categoria.Descricao);
            Console.WriteLine("----------------------");
        }
    }
}