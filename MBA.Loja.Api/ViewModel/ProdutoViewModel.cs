using MBA.Loja.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace MBA.Loja.Api.ViewModel
{
    public class ProdutoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        public Guid VendedorId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid CategoriaId { get; set; }

        [Required(ErrorMessage =" O campo {0} é obrigatório")]
        [StringLength(300, ErrorMessage ="O campo {0} precisa ter entre {2} e {3} caracteres", MinimumLength =2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = " O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {3} caracteres", MinimumLength = 2)]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = " O campo {0} é obrigatório")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = " O campo {0} é obrigatório")]
        public int Estoque { get; set; }

        public DateTime DataCadastro { get; set; }


        public string? Imagem { get; set; }

        public string? NomeCategoria { get; set; }

        public string? NomeVendedor { get; set; }
    }
}
