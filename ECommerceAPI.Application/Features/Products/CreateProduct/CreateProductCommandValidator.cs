using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ECommerceAPI.Application.Features.Products.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
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
