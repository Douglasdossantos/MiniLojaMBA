using FluentValidation;

namespace MBA.Loja.Business.Models.Validation
{
    public class CategoriaValidation : AbstractValidator<Categoria>
    {
        public CategoriaValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O campo {PortpertyName} precisa ser fornecido")
                .Length(3, 20).WithMessage("O campo {PorpertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
