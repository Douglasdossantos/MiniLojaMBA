using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBA.Loja.App.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        public string? Nome { get; set; }

        public string?  Image { get; set; }
        
        [NotMapped]
        [DisplayName("Image do Produto")]
        public IFormFile? ImageUpload { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

    }
}
