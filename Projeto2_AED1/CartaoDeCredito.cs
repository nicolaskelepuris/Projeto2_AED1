namespace Projeto2_AED1
{
    public class CartaoDeCredito
    {
        public string NomeDoTitular { get; private set; }
        public string Numero { get; private set; }
        public string CodigoDeSeguranca { get; private set; }

        public CartaoDeCredito(string nomeDoTitular, string numero, string codigoDeSeguranca)
        {
            NomeDoTitular = nomeDoTitular;
            Numero = numero;
            CodigoDeSeguranca = codigoDeSeguranca;
        }
    }
}