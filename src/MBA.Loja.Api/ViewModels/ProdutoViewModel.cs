using MBA.Loja.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace MBA.Loja.Api.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [StringLength(200,MinimumLength =3,ErrorMessage ="O campo {0} precisa conter {2} há {1} caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, MinimumLength =3, ErrorMessage = "O campo {0} precisa conter {2} há {1} caracteres")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal? Preco { get; set; }
        public int Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public string? Imagem { get; set; }

        public Guid CategoriaId { get; set; }
        public string? NomeCategoria { get; set; }
        public Guid VendedorId { get; set; }
        public string? NomeVendedor { get; set; }
    }
}
