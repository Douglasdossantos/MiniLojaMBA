using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Loja.Business.Models.Validations
{
    public  class CategoriaValidation : AbstractValidator<Categoria> 
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
