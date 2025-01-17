using System;

namespace GerenciadorProdutos
{
    class Program
    {
        static List <Produto> listaProdutos = new List<Produto>();
        static void Main(string[] args)
        {
            bool continuarPrograma = true; 
            while (continuarPrograma == true)
            {
                int opcao = menu();
                Console.Clear();

                switch (opcao)
                {
                    case 1:
                    infoProdutos();
                    break;

                    case 2:
                    novoProduto();
                    break;

                    case 3:
                    alterarProduto();
                    break;

                    case 4:
                    continuarPrograma = false;
                    Console.WriteLine("Fim do programa.");
                    break;

                    default:
                    Console.WriteLine("Opção inválida");
                    break;
                }
            }  
        }

        static int menu()
        {
            Console.WriteLine("Digite a ação desejada pelo número correspondente:");
            Console.WriteLine("1.Ver produtos     2.Adicionar novo produto     3.Alterar produtos      4.Sair do programa");
            string respostaUsuario = Console.ReadLine() ?? "";
            if (string.IsNullOrEmpty(respostaUsuario) || !int.TryParse(respostaUsuario, out int opcao ))
            {
                Console.WriteLine("Entrada inválida!");
                return -1;
            }
            return opcao;
        }

        static void infoProdutos()
        {
            if (listaProdutos.Count == 0)
            {
                Console.WriteLine("Nenhum produto encontrado");
                Console.WriteLine("Pressione qualquer tecla para voltar");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            foreach (var Produto in listaProdutos)
            {
                Console.WriteLine($"Nome: {Produto.nomeProduto}\t Preço: {Produto.precoProduto :c}\t Quantidade em estoque: {Produto.estoqueProduto}");
            }
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar");
            Console.ReadKey();
            Console.Clear();

        }

        static void novoProduto()
        {
            Console.WriteLine("Informe o nome do produto:");
            string novoProdutoNome = Console.ReadLine() ?? "";
            foreach (var Produto in listaProdutos)
            {
                if (string.IsNullOrEmpty(novoProdutoNome) || novoProdutoNome.ToLower() == Produto.nomeProduto.ToLower())
                {
                    Console.WriteLine("Produto já adicionado ao estoque!");
                    Console.WriteLine("Pressione qualquer tecla para voltar");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }
            }

            Console.WriteLine("Informe o preço do produto:");
            string precoInput = Console.ReadLine() ?? "";
            if (string.IsNullOrEmpty(precoInput) || !float.TryParse(precoInput, out float novoProdutoPreco) || novoProdutoPreco < 0)
            {
                Console.WriteLine("Operação inválida!");
                Console.WriteLine("Pressione qualquer tecla para voltar");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            Console.WriteLine("Informe a quantidade em estoque do produto:");
            string estoqueInput = Console.ReadLine() ?? "";
            if (string.IsNullOrEmpty(estoqueInput) || !int.TryParse(estoqueInput, out int novoProdutoEstoque) || novoProdutoEstoque < 0)
            {
                Console.WriteLine("Operação inválida!");
                Console.WriteLine("Pressione qualquer tecla para voltar");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            listaProdutos.Add(new Produto(novoProdutoNome, novoProdutoPreco, novoProdutoEstoque));

            Console.Clear();
            Console.WriteLine($"Nome do produto: {novoProdutoNome}\t preço: {novoProdutoPreco:c}\t quantidade em estoque: {novoProdutoEstoque}");
            Console.WriteLine();
            return;
        }

        static void alterarProduto()
        {
            Console.WriteLine("Digite o nome do produto que deseja alterar:");
            string altProduto = Console.ReadLine()?? "";
            bool produtoEncontrado = false;
            for (int i = 0; i < listaProdutos.Count; i++)
            {
                var Produto = listaProdutos[i];
                if (string.IsNullOrEmpty(altProduto) || altProduto.ToLower() == Produto.nomeProduto.ToLower())
                {
                    produtoEncontrado = true;
                    Console.WriteLine($"Nome: {Produto.nomeProduto}\t Preço: {Produto.precoProduto :c}\t Quantidade em estoque: {Produto.estoqueProduto}");
                    Console.WriteLine();
                    Console.WriteLine("Escolha o que deseja alterar pelo número correspondente:");
                    Console.WriteLine("1.Nome 2.Preço 3.Estoque 4.Excluir 5.Voltar");
                    string altInput = Console.ReadLine() ?? "";
                    if (string.IsNullOrEmpty(altInput) || !int.TryParse(altInput, out int alterar))
                    {
                        Console.WriteLine("Operação inválida!");
                        return;
                    }
                    switch (alterar)
                    {
                        case 1:
                        Console.WriteLine("Redefinir o nome do produto:");
                        string alterarNomeInput = Console.ReadLine() ?? "";
                        if (string.IsNullOrEmpty(alterarNomeInput) || alterarNomeInput == Produto.nomeProduto)
                        {
                            Console.WriteLine("Nome vazio ou inválido");
                            Console.WriteLine("Pressione qualquer tecla para voltar");
                            Console.ReadKey();
                            Console.Clear();
                            return;
                        }
                        Produto.nomeProduto = alterarNomeInput;
                        break;

                        case 2:
                        Console.WriteLine("Redefinir o preço do produto:");
                        string alterarPrecoInput = Console.ReadLine() ?? "";
                        if (string.IsNullOrEmpty(alterarPrecoInput) || !float.TryParse(alterarPrecoInput, out float novoPreco) || novoPreco < 0)
                        {
                            Console.WriteLine("Novo valor de preço inválido");
                            Console.WriteLine("Pressione qualquer tecla para voltar");
                            Console.ReadKey();
                            Console.Clear();
                            return;
                        }
                        Produto.precoProduto = novoPreco;
                        break;

                        case 3:
                        Console.WriteLine("Redefinir a quantidade em estoque do produto:");
                        string alterarEstoqueInput = Console.ReadLine() ?? "";
                        if (string.IsNullOrEmpty(alterarEstoqueInput) || !int.TryParse(alterarEstoqueInput, out int novoEstoque) || novoEstoque < 0)
                        {
                            Console.WriteLine("Novo valor de estoque inválido!");
                            Console.WriteLine("Pressione qualquer tecla para voltar");
                            Console.ReadKey();
                            Console.Clear();
                            return;
                        }
                        Produto.estoqueProduto = novoEstoque;
                        break;

                        case 4:
                        Console.WriteLine($"{Produto.nomeProduto} foi excluído do estoque.");
                        listaProdutos.RemoveAt(i);
                        break;

                        case 5:
                        Console.Clear();
                        Console.WriteLine("Voltando ao menu");
                        break;

                        default:
                        Console.WriteLine("Opção inválida");
                        break;
                    }
                    Console.WriteLine("Alteração concluída, pressione qualquer tecla para voltar:");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                } 
            }
            if (!produtoEncontrado)
            {
                Console.WriteLine("Nenhum produto encontrado");
                Console.WriteLine("Pressione qualquer tecla para voltar");
                Console.ReadKey();
                Console.Clear();
                return;
            }
        }
    }

    class Produto
    {
        public string nomeProduto {get; set;}
        public float precoProduto {get; set;}
        public int estoqueProduto {get; set;}

        public Produto()
        {
            nomeProduto = "Produto não identificado";
            precoProduto = 0f;
            estoqueProduto = 0;
        }

        public Produto(string name, float price, int stock)
        {
            nomeProduto = name;
            precoProduto = price;
            estoqueProduto = stock;
        }
    }
}