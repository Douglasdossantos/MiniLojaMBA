using MBA.Loja.Business.Enums;
using MBA.Loja.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace MBA.Loja.Api.ViewModel
{
    public class VendedorViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {3} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {3} caracteres", MinimumLength = 2)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(15, ErrorMessage = "O campo {0} precisa ter entre {2} e {3} caracteres", MinimumLength = 2)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {3} caracteres", MinimumLength = 11)]
        public string Documento { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
        public EnumDocumento TipoDocumento { get; set; }
    }
}
