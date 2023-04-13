using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;

namespace Projeto_loja_Virtual
{

    class Program
    {
        static List<Produto> listaProdutos = new List<Produto>();
        static List<Categoria> listaCategorias = new List<Categoria>();
        static List<Cliente> listaClientes = new List<Cliente>();
        static List<Venda> listaVendas = new List<Venda>();

        static void Main(string[] args)
        {
            int opcao = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Cadastrar Categoria");
                Console.WriteLine("2 - Listar Categorias");
                Console.WriteLine("3 - Cadastrar Produto");
                Console.WriteLine("4 - Listar Produtos");
                Console.WriteLine("5 - Cadastrar Cliente");
                Console.WriteLine("6 - Listar Clientes");
                Console.WriteLine("7 - Registrar Venda");
                Console.WriteLine("8 - Listar Vendas");
                Console.WriteLine("0 - Sair");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CategoriaUI.CadastrarCategoria(listaCategorias);
                        break;
                    case 2:
                        CategoriaUI.ListarCategorias(listaCategorias);
                        break;
                    case 3:
                        ProdutoUI.CadastrarProduto(listaProdutos, listaCategorias);
                        break;
                    case 4:
                        ProdutoUI.ListarProdutos(listaProdutos);
                        break;
                    case 5:
                        ClienteUI.CadastrarCliente(listaClientes);
                        break;
                    case 6:
                        ClienteUI.ListarClientes(listaClientes);
                        break;
                    case 7:
                        VendaUI.CadastrarVenda(listaVendas, listaClientes, listaProdutos);
                        break;
                    case 8:
                        VendaUI.ListarVenda(listaVendas);
                        break;
                    case 0:
                        Console.WriteLine("Programa encerrado.");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Digite novamente.");
                        break;
                }


                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();

            } while (opcao != 0);
        }
    }

    class Categoria
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

    class Produto
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

    class Cliente
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

    class Venda
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

    class ItemVenda
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

    class CategoriaUI
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

    class ProdutoUI
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

    class ClienteUI
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
    class VendaUI
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
}


