using System;
using System.Collections.Generic;

namespace Projeto2_AED1
{
    public static class GerenciadorDeCadastroDeProduto
    {
        public static void CadastrarProdutosRandomicosNoEstoque()
        {
            for (int i = 0; i < 10; i++)
            {
                var id = i;
                var nome = "Produto " + (i+1);
                var descricao = "Apenas o produto " + (i+1);
                var preco = (Math.Round(new Random().NextDouble(), 2) * 100.00) + 20.00;
                var quantidadeNoEstoque = new Random().Next(minValue: 1, maxValue:101);

                var produto = new Produto(id, nome, descricao, preco, quantidadeNoEstoque);
            }
        }
    }
}