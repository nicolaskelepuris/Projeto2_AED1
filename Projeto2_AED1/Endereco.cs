namespace Projeto2_AED1
{
    public class Endereco
    {
        public string Cidade { get; private set; }
        public string Bairro { get; private set; }
        public string Rua { get; private set; }
        public string Numero { get; private set; }        
        public string Complemento { get; private set; }

        public Endereco(string cidade, string bairro, string rua, string numero, string complemento)
        {
            Cidade = cidade;
            Bairro = bairro;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
        }
    }
}