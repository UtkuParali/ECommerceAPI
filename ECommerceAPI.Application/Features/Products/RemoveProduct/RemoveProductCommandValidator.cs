using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ECommerceAPI.Application.Features.Products.RemoveProduct
{
    public class RemoveProductCommandValidator : AbstractValidator<RemoveProductCommand>
    {
        public RemoveProductCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Ürün Id boş olamaz.")
                .NotNull().WithMessage("Ürün Id null olamaz.");
        }
    }
}
