using System.ComponentModel.DataAnnotations;

namespace MBA.Loja.Api.ViewModels
{
    public class AddCategoriaViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "O campo {0} precisa conter {2} há {1} caracteres")]
        public string Nome { get; set; }
        public bool Ativo { get; set; }

    }
}
