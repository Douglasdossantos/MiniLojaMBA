using MBA.Loja.Business.Enums;

namespace MBA.Loja.App.ViewModels.Vendedor
{
    public class VendedorViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Documento { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; } = false;
        public EnumDocumento TipoDocumento { get; set; }

    }
}
