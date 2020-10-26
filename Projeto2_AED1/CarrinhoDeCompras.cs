using System;
using System.Collections.Generic;

namespace Projeto2_AED1
{
    public class CarrinhoDeCompras
    {
        public Usuario Usuario { get; private set; }
        Dictionary<Produto, int> produtosComQuantidade;
        public CarrinhoDeCompras(Usuario usuario)
        {
            produtosComQuantidade = new Dictionary<Produto, int>();
            Usuario = usuario;
        }

        public void AdicionarOuAtualizarProdutoEQuantidade(Produto produto, int quantidade)
        {
            if (quantidade > produto.QuantidadeNoEstoque)
            {
                quantidade = produto.QuantidadeNoEstoque;
                Console.WriteLine("\nA quantidade solicitada do produto {0} excede a quantidade disponivel no estoque de {1} itens!",
                                produto.Nome, produto.QuantidadeNoEstoque);
            }

            if (!produtosComQuantidade.ContainsKey(produto))
            {
                produtosComQuantidade.Add(produto, quantidade);
                Console.WriteLine("\nItem adicionado ao carrinho de compras! Produto: {0}, Quantidade: {1}!", produto.Nome, quantidade);
            }
            else
            {
                produtosComQuantidade[produto] = quantidade;
                Console.WriteLine("\nQuantidade atualizada! Produto: {0}, Quantidade: {1}!", produto.Nome, quantidade);
            }
        }

        public void RemoverProduto(Produto produto)
        {
            if (produtosComQuantidade.ContainsKey(produto))
            {
                produtosComQuantidade.Remove(produto);
            }
            else
            {
                Console.WriteLine("\nFalha ao remover produto do carrinho de compras! O produto nao foi encontrado no carrinho!");
            }
        }

        public int GetQuantidadeDoProduto(Produto produto)
        {
            if (produtosComQuantidade.ContainsKey(produto))
            {
                return produtosComQuantidade[produto];
            }
            else
            {
                Console.WriteLine("\nFalha ao obter quantidade do produto! O produto nao foi encontrado no carrinho!");
                return -1;
            }
        }

        public void PrintCarrinhoDeCompras()
        {
            Console.WriteLine("\nProdutos no carrinho de compras:\n");

            double valorTotal = default;

            foreach (var item in produtosComQuantidade)
            {
                var produto = item.Key;
                var quantidade = item.Value;
                var valorDoItem = produto.Preco * quantidade;

                Console.WriteLine("Nome: {0} ------ Preco da unidade: {1} ------ Quantidade: {2} ------ Quantidade disponivel no estoque: {3} ------ Preco: {4}",
                                produto.Nome, produto.Preco, quantidade, produto.QuantidadeNoEstoque, valorDoItem);

                valorTotal += valorDoItem;
            }

            Console.WriteLine("\nValor total: {0}", valorTotal);
        }

        public void Esvaziar()
        {
            produtosComQuantidade.Clear();
        }

        public Dictionary<Produto, int> GetCopiaDoDictionaryComProdutosEQuantidades()
        {
            return new Dictionary<Produto, int>(produtosComQuantidade);
        }
    }
}