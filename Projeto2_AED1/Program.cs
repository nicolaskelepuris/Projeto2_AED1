using System;

namespace Projeto2_AED1
{
    class Program
    {
        static void Main(string[] args)
        {
            GerenciadorDeCadastroDeProduto.CadastrarProdutosRandomicosNoEstoque();

            var usuario = GerenciadorDeCadastroDeUsuario.GetUsuarioPeloConsole();
            GerenciadorDeCadastroDeUsuario.CadastrarUsuario(usuario);

            AtendimentoAoCliente.PrintProdutosDisponiveis();
        }
    }
}
