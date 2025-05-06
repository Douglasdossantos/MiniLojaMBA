using System.ComponentModel.DataAnnotations;

namespace MBA.Loja.App.ViewModels.Categoria
{
    public class CategoriaViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}
