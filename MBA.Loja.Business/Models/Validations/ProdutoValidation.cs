using FluentValidation;


namespace MBA.Loja.Business.Models.Validations
{
    public class ProdutoValidation : AbstractValidator<Produto> 
    {
        public ProdutoValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage(" O campo {PorpertyName} precisa ter entre {MinLength} e {MaxLength} carateteres");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage(" O campo {PorpertyName} precisa ter entre {MinLength} e {MaxLength} carateteres");

            RuleFor(x => x.Preco)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");


        }
    }
}
