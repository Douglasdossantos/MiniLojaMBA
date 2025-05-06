using MBA.Loja.Business.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MBA.Loja.App.ViewModels.Categoria
{
    public class CategoriaComboBoxViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } 
    }
}
