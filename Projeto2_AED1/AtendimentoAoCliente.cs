using System;

namespace Projeto2_AED1
{
    public static class AtendimentoAoCliente
    {
        public static void PrintProdutosDisponiveis()
        {
            var produtos = Estoque.GetListaDeProdutosCadastrados();

            Console.WriteLine("\nLista dos produtos disponiveis:\n");

            foreach (var produto in produtos)
            {
                Console.WriteLine("Nome: {0} ------ Descricao: {1} ------ Preco: {2} ------ Quantidade disponivel: {3} ------ Id: {4}",
                                produto.Nome, produto.Descricao, produto.Preco, produto.QuantidadeNoEstoque, produto.Id);
            }
        }
    }
}