using System.ComponentModel.DataAnnotations;

namespace MBA.Loja.App.ViewModels.Categoria
{
    public class CreateCategoriaViewModel
    {
        [Required(ErrorMessage ="O campo {0} é obrigatório!")]
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}
