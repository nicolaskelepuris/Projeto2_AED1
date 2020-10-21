namespace Projeto2_AED1
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public double Preco { get; private set; }
        public int QuantidadeNoEstoque
        {
            get { return Estoque.GetQuantidadeDoProduto(this); }
        }

        public Produto(int id, string nome, string descricao, double preco, int quantidadeNoEstoque)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque.AdicionarProdutoEQuantidade(this, quantidadeNoEstoque);
        }
    }
}