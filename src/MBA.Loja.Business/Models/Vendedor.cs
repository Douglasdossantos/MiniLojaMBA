using MBA.Loja.Business.Enums;

namespace MBA.Loja.Business.Models
{
    public class Vendedor : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Documento { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
        public bool Ativo { get; set; } = false;
        public EnumDocumento TipoDocumento { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }
    }
}
