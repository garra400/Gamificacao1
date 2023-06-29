using System;
using System.Collections.Generic;
using System.Linq;
using gamificacao1.Models;

namespace gamificacao1.UI;
public class ClienteUI
{
    public static void CadastrarCliente(List<Cliente> listaClientes)
    {
        Console.Clear();
        Console.WriteLine("CADASTRO DE CLIENTE\n");

        Console.Write("Nome do cliente: ");
        string nome = Console.ReadLine();

        Console.Write("E-mail do cliente: ");
        string email = Console.ReadLine();

        int id = listaClientes.Count + 1;

        Cliente cliente = new Cliente(id, nome, email);

        listaClientes.Add(cliente);

        Console.WriteLine("\nCliente cadastrado com sucesso!");
    }

    public static void ListarClientes(List<Cliente> listaClientes)
    {
        Console.Clear();
        Console.WriteLine("LISTAGEM DE CLIENTES\n");

        foreach (Cliente cliente in listaClientes)
        {
            Console.WriteLine("ID: " + cliente.Id);
            Console.WriteLine("Nome: " + cliente.Nome);
            Console.WriteLine("E-mail: " + cliente.Email);
            Console.WriteLine("--------------------------");
        }
    }
    
}