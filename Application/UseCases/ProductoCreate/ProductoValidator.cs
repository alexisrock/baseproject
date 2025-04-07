using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.ProductoCreate;
using FluentValidation;

namespace Application.UseCases.ProductoCreate
{
    public class ProductoValidator : AbstractValidator<ProductoRequest>
    {


        public ProductoValidator() {
            RuleFor(x => x.Name)
                 .NotEmpty().WithMessage("El nombre es obligatorio")
                 .MinimumLength(2).WithMessage("El nombre debe tener al menos 2 caracteres");


        }


    }
}
