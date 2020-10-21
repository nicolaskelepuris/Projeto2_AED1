namespace Projeto2_AED1
{
    public class Usuario
    {
        public string Nome { get; private set; }
        public Endereco Endereco { get; private set; }
        public CartaoDeCredito CartaoDeCredito { get; private set; }

        public Usuario(string nome, Endereco endereco, CartaoDeCredito cartaoDeCredito)
        {
            Nome = nome;
            Endereco = endereco;
            CartaoDeCredito = cartaoDeCredito;
        }
    }
}