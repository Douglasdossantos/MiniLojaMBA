using MBA.Loja.Business.Enums;
using System.ComponentModel.DataAnnotations;

namespace MBA.Loja.Api.ViewModels
{
    public class VendedorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, MinimumLength =3, ErrorMessage = "O campo {0} precisa conter {2} há {1} caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, MinimumLength =5, ErrorMessage = "O campo {0} precisa conter {2} há {1} caracteres")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200,MinimumLength =8, ErrorMessage = "O campo {0} precisa conter {2} há {1} caracteres")]
        public string? Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O campo {0} precisa conter {2} há {1} caracteres")]
        public string? Documento { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
        public bool Ativo { get; set; } = false;
        public EnumDocumento TipoDocumento { get; set; }

        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}
