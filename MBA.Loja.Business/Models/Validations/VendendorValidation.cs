using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Loja.Business.Models.Validations
{
    public class VendendorValidation : AbstractValidator<Vendedor>
    {
        public VendendorValidation()
        {
            RuleFor(v => v.Nome)
                .NotEmpty()
                .WithMessage("O campo {PorpertyName} precisa ser fornecido")
                .Length(3, 200).WithMessage("O campo {PorpertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
            RuleFor(v => v.Email)
                .NotEmpty()
                .WithMessage("O campo {PorpertyName} precisa ser fornecido")
                .EmailAddress().WithMessage("O {PropertyName} informado é invalido");

        }
    }
}
