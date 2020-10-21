using System;
using System.Collections.Generic;

namespace Projeto2_AED1
{
    public static class GerenciadorDeCadastroDeUsuario
    {
        static List<Usuario> usuariosCadastrados = new List<Usuario>();

        public static void CadastrarUsuario(Usuario usuario)
        {
            if (!usuariosCadastrados.Contains(usuario))
            {
                usuariosCadastrados.Add(usuario);
            }
            else
            {
                Console.WriteLine("\nFalha ao cadastrar usuario! O usuario ja esta cadastrado!");
            }
        }

        public static void RemoverUsuario(Usuario usuario)
        {
            if (usuariosCadastrados.Contains(usuario))
            {
                usuariosCadastrados.Remove(usuario);
            }
            else
            {
                Console.WriteLine("\nFalha ao remover usuario! O usuario nao foi encontrado!");
            }
        }

        public static Usuario GetUsuarioPeloConsole()
        {
            var nome = GetNomeDoUsuarioPeloConsole();

            var endereco = GetEnderecoDoUsuarioPeloConsole();

            var cartaoDeCredito = GetCartaoDeCreditoDoUsuarioPeloConsole();

            return new Usuario(nome, endereco, cartaoDeCredito);
        }

        private static string GetNomeDoUsuarioPeloConsole()
        {
            Console.WriteLine("Favor informar os dados do usuario que sera cadastrado:\nNome:");
            return Console.ReadLine();
        }

        private static Endereco GetEnderecoDoUsuarioPeloConsole()
        {
            Console.WriteLine("\nDados do endereço de entrega:\nCidade:");
            var cidade = Console.ReadLine();

            Console.WriteLine("\nBairro:");
            var bairro = Console.ReadLine();

            Console.WriteLine("\nRua:");
            var rua = Console.ReadLine();

            Console.WriteLine("\nNumero:");
            var numero = Console.ReadLine();

            Console.WriteLine("\nComplemento:");
            var complemento = Console.ReadLine();

            return new Endereco(cidade, bairro, rua, numero, complemento);
        }

        private static CartaoDeCredito GetCartaoDeCreditoDoUsuarioPeloConsole()
        {
            Console.WriteLine("\nDados do cartao de credito que sera utilizado para realizar as compras:\nNome do titular do cartao:");
            var nomeDoTitular = Console.ReadLine();

            Console.WriteLine("\nNumero:");
            var numero = Console.ReadLine();

            Console.WriteLine("\nCodigo de seguranca:");
            var codigoDeSeguranca = Console.ReadLine();

            return new CartaoDeCredito(nomeDoTitular, numero, codigoDeSeguranca);
        }
    }
}