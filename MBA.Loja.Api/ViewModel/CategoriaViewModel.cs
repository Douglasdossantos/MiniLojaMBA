using System.ComponentModel.DataAnnotations;

namespace MBA.Loja.Api.ViewModel
{
    public class CategoriaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório.")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {3} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        public bool Ativo { get;  set; }

    }
}
