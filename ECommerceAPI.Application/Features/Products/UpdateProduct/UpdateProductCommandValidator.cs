using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ECommerceAPI.Application.Features.Products.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Ürün Id boş olamaz.")
                .NotNull().WithMessage("Ürün Id null olamaz.");
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Ürün adı boş olamaz.")
                .NotNull().WithMessage("Ürün adı null olamaz.");
            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Ürün fiyatı sıfırdan büyük olmalıdır.");
            RuleFor(p => p.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("Ürün stoğu negatif olamaz.");
        }
    }
}
