using FluentValidation;
using MBA.Loja.Business.Enums;

namespace MBA.Loja.Business.Models.Validation
{
    public class VendendorValidation : AbstractValidator<Vendedor>
    {
        public VendendorValidation()
        {
            RuleFor(v => v.Nome)
                .NotEmpty()
                .WithMessage("O campo {PorpertyName} precisa ser fornecido")
                .Length(3, 200).WithMessage("O campo {PorpertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
            When(v => v.TipoDocumento == EnumDocumento.CPF, () =>
            {

            });
            When(v => v.TipoDocumento == EnumDocumento.CNPJ, () =>
            {

            });
            RuleFor(v => v.Email)
                .NotEmpty()
                .WithMessage("O campo {PorpertyName} precisa ser fornecido")
                .EmailAddress().WithMessage("O {PropertyName} informado é invalido");
        }
    }
}
