using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto2_AED1
{
    public static class Estoque
    {
        static Dictionary<Produto, int> produtosComQuantidade = new Dictionary<Produto, int>();

        public static void AdicionarProdutoEQuantidade(Produto produto, int quantidade)
        {
            if (!produtosComQuantidade.ContainsKey(produto))
            {
                produtosComQuantidade.Add(produto, quantidade);
            }
            else
            {
                produtosComQuantidade[produto] = quantidade;

                Console.WriteLine("\nFalha ao adicionar produto ao estoque! O estoque ja possui esse produto, portanto apenas sua quantidade foi atualizada!");
            }
        }

        public static void RemoverProduto(Produto produto)
        {
            if (produtosComQuantidade.ContainsKey(produto))
            {
                produtosComQuantidade.Remove(produto);
            }
            else
            {
                Console.WriteLine("\nFalha ao remover produto do estoque! O produto nao foi encontrado no estoque");
            }
        }

        public static void AtualizarQuantidade(Produto produto, int novaQuantidade)
        {
            if (produtosComQuantidade.ContainsKey(produto))
            {
                produtosComQuantidade[produto] = novaQuantidade;
            }
            else
            {
                Console.WriteLine("\nFalha ao atualizar quantidade do produto! O produto nao foi encontrado no estoque");
            }
        }

        public static int GetQuantidadeDoProduto(Produto produto)
        {
            if (produtosComQuantidade.ContainsKey(produto))
            {
                return produtosComQuantidade[produto];
            }
            else
            {
                Console.WriteLine("\nFalha ao obter quantidade do produto! O produto nao foi encontrado no estoque");
                return -1;
            }
        }

        public static Produto GetProdutoCadastradoPeloId(int id)
        {
            return produtosComQuantidade.Keys.Where(produto => produto.Id == id).FirstOrDefault();
        }

        public static List<Produto> GetListaDeProdutosCadastrados()
        {
            return new List<Produto>(produtosComQuantidade.Keys.ToList());
        }

        public static void PrintProdutosDisponiveis()
        {
            var produtos = GetListaDeProdutosCadastrados();

            Console.WriteLine("\nLista dos produtos disponiveis no estoque:\n");

            foreach (var produto in produtos)
            {
                Console.WriteLine("Nome: {0} ------ Descricao: {1} ------ Preco: {2} ------ Quantidade disponivel: {3} ------ Id: {4}",
                                produto.Nome, produto.Descricao, produto.Preco, produto.QuantidadeNoEstoque, produto.Id);
            }
        }
    }
}