using System;
using System.Threading;

namespace Projeto2_AED1
{
    public static class AtendimentoAoCliente
    {
        public static OpcaoDoCliente GetOpcaoDoCliente()
        {
            Console.WriteLine("\nInforme o que deseja fazer: (1) Realizar pagamento, (2) Continuar comprando, (3) Cancelar compra e voltar ao inicio");
            var opcaoDoCliente = (OpcaoDoCliente)(int.Parse(Console.ReadLine()) - 1);

            Console.Clear();

            return opcaoDoCliente;
        }

        public static void RealizaOpcaoDoCliente(CarrinhoDeCompras carrinhoDeCompras, OpcaoDoCliente opcaoDoCliente)
        {
            switch (opcaoDoCliente)
            {
                case OpcaoDoCliente.RealizarPagamento:
                    RealizarPagamento(carrinhoDeCompras);
                    break;
                case OpcaoDoCliente.ContinuarComprando:
                    ContinuarComprando(carrinhoDeCompras);
                    break;
                case OpcaoDoCliente.CancelarCompra:
                    CancelarCompraEVoltarAoInicio(carrinhoDeCompras);
                    break;
                default:
                    Console.WriteLine("\nComando invalido, tente novamente");
                    opcaoDoCliente = GetOpcaoDoCliente();
                    AtendimentoAoCliente.RealizaOpcaoDoCliente(carrinhoDeCompras, opcaoDoCliente);
                    break;
            }
        }

        private static void ContinuarComprando(CarrinhoDeCompras carrinhoDeCompras)
        {
            Estoque.PrintProdutosDisponiveis();
            GetProdutosQueOUsuarioDesejaComprar(carrinhoDeCompras);

            var opcaoDoCliente = AtendimentoAoCliente.GetOpcaoDoCliente();
            AtendimentoAoCliente.RealizaOpcaoDoCliente(carrinhoDeCompras, opcaoDoCliente);
        }

        private static void CancelarCompraEVoltarAoInicio(CarrinhoDeCompras carrinhoDeCompras)
        {
            carrinhoDeCompras.Esvaziar();
            Estoque.PrintProdutosDisponiveis();
            GetProdutosQueOUsuarioDesejaComprar(carrinhoDeCompras);

            var opcaoDoCliente = AtendimentoAoCliente.GetOpcaoDoCliente();
            AtendimentoAoCliente.RealizaOpcaoDoCliente(carrinhoDeCompras, opcaoDoCliente);
        }

        public static void GetProdutosQueOUsuarioDesejaComprar(CarrinhoDeCompras carrinhoDeCompras)
        {
            bool clienteContinuaComprando = true;
            while (clienteContinuaComprando)
            {
                Console.WriteLine("\nInforme o Id do produto que deseja:");
                var id = int.Parse(Console.ReadLine());

                Console.WriteLine("\nInforme a quantidade do produto de Id {0} que deseja:", id);
                var quantidade = int.Parse(Console.ReadLine());

                var resultadoFoiBemSucedido = AdicionaProdutoAoCarrinho(id, quantidade, carrinhoDeCompras);

                clienteContinuaComprando = resultadoFoiBemSucedido ? ClienteDesejaContinuarComprando() : true;
            }
        }

        private static void RealizarPagamento(CarrinhoDeCompras carrinhoDeCompras)
        {
            Console.WriteLine("Realizando pagamento utilizando o cartao de credito cadastrado, aguarde...");

            // simula a validacao do pagamento
            Thread.Sleep(2000);

            Console.WriteLine("\nPagamento realizado com sucesso!");

            PrintProdutosComprados(carrinhoDeCompras);

            EnviarProdutos(carrinhoDeCompras);
        }

        private static void EnviarProdutos(CarrinhoDeCompras carrinhoDeCompras)
        {
            Console.WriteLine("\nOs produtos estao sendo enviados e chegarao em ate 10 dias uteis");

            var usuario = carrinhoDeCompras.Usuario;
            Console.WriteLine("\nNome do destinatario: {0}\nEndereco:\nCidade: {1}, Bairro: {2}, Rua: {3}, Numero: {4}",
                            usuario.Nome, usuario.Endereco.Cidade, usuario.Endereco.Bairro, usuario.Endereco.Rua, usuario.Endereco.Numero);
        }

        private static void PrintProdutosComprados(CarrinhoDeCompras carrinhoDeCompras)
        {
            Console.WriteLine("\nProdutos comprados:\n");

            double valorTotal = default;

            foreach (var item in carrinhoDeCompras.GetCopiaDoDictionaryComProdutosEQuantidades())
            {
                var produto = item.Key;
                var quantidade = item.Value;
                var valorDoItem = produto.Preco * quantidade;

                Console.WriteLine("Nome: {0} ------ Preco da unidade: {1} ------ Quantidade: {2} ------ Preco: {3}",
                                produto.Nome, produto.Preco, quantidade, valorDoItem);

                valorTotal += valorDoItem;
            }
        }
        private static bool AdicionaProdutoAoCarrinho(int id, int quantidade, CarrinhoDeCompras carrinhoDeCompras)
        {
            var produto = Estoque.GetProdutoCadastradoPeloId(id);

            if (produto == null)
            {
                Console.WriteLine("\nNao foi encontrado produto para o id informado, tente novamente");
                return false;
            }
            else
            {
                carrinhoDeCompras.AdicionarOuAtualizarProdutoEQuantidade(produto, quantidade);
                carrinhoDeCompras.PrintCarrinhoDeCompras();
                return true;
            }
        }

        private static bool ClienteDesejaContinuarComprando()
        {
            Console.WriteLine("\nContinuar comprando? digite \"sim\" ou \"nao\"");
            var clienteDesejaContinuarComprando = Console.ReadLine();

            if (clienteDesejaContinuarComprando == "nao")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}