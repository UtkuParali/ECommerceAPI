using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ECommerceAPI.Application.Features.Products.GetAllProducts
{
    public class GetAllProductsQueryValidator : AbstractValidator<GetAllProductsQuery>
    {
        public GetAllProductsQueryValidator()
        {
            RuleFor(query => query.Page)
                .GreaterThanOrEqualTo(0).WithMessage("Sayfa numarası sıfırdan küçük olamaz.");
            RuleFor(query => query.Size)
                .GreaterThan(0).WithMessage("Sayfa boyutu sıfırdan büyük olmalıdır.");
        }
    }
}
