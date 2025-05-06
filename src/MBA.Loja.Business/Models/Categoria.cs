namespace MBA.Loja.Business.Models
{
    public class Categoria : Entity
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public List<Produto> Produtos { get; set; } = new();
    }
}
