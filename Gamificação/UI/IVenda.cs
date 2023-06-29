using System;
using System.Collections.Generic;
using System.Linq;
using gamificacao1.Models;

namespace gamificacao1.UI;
public class VendaUI
{
    public static void CadastrarVenda(List<Venda> listavendas, List<Cliente> listaClientes, List<Produto> listaProdutos)
    {
        Console.Clear();
        Console.WriteLine("CADASTRO DE Venda\n");

        Console.WriteLine("\nSelecione o Cliente:");

        ClienteUI.ListarClientes(listaClientes);

        Console.Write("Digite o ID da categoria: ");
        int idCliente = int.Parse(Console.ReadLine());
        Cliente Cliente = listaClientes.Find(c => c.Id == idCliente);
        int id = listavendas.Count + 1;
        Venda venda = new Venda(id, Cliente);
        listavendas.Add(venda);
        char x = 'S';
        while (x== 's' || x == 'S')
        {
            Console.Clear();
            Console.WriteLine("== Adicionar item à venda ==");

            // Lista todos os produtos cadastrados
            Console.WriteLine("\nProdutos disponíveis:");
            foreach (Produto p in listaProdutos)
            {
                Console.WriteLine($"ID: {p.Id} | Produto: {p.Nome} | Preço: {p.Preco:C}");
            }
            Console.Write("\nDigite o ID do produto que deseja adicionar: ");
            int idProduto = int.Parse(Console.ReadLine());

            // Busca o produto com o ID informado na lista de produtos
            Produto produto = listaProdutos.Find(x => x.Id == idProduto);

            if (produto == null)
            {
                Console.WriteLine("\nProduto não encontrado!");
            }
            else
            {
                Console.Write("Digite a quantidade desejada: ");
                int quantidade = int.Parse(Console.ReadLine());

                // Cria um objeto ItemVenda e adiciona à lista de itens da venda
                ItemVenda item = new ItemVenda(produto, quantidade);
                venda.ItensVenda.Add(item);
                Console.WriteLine("\nItem adicionado à venda!");

                Console.Write("\nDeseja adicionar mais um item à venda? (S/N) ");
                x = char.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine("\nVenda cadastrado com sucesso!");
    }

    public static void ListarVenda(List<Venda> listaVendas)
    {
        if (listaVendas.Count == 0)
        {
            Console.WriteLine("Não há vendas registradas.");
        }
        else
        {
            Console.WriteLine("Vendas registradas:");
            foreach (Venda venda in listaVendas)
            {
                Console.WriteLine($"ID da Venda: {venda.Id}");
                Console.WriteLine($"Nome do Cliente: {venda.Cliente.Nome}");
                Console.WriteLine("Produtos:");
                foreach (ItemVenda item in venda.ItensVenda)
                {
                    Console.WriteLine($"- {item.Produto.Nome}:");
                    Console.WriteLine($"  Preço individual: R${item.Produto.Preco:F2}");
                    Console.WriteLine($"  Quantidade comprada: {item.Quantidade}");
                }
                Console.WriteLine($"Preço total da compra: R${venda.CalcularValorTotal():F2}\n");
            }
        }
    }

}