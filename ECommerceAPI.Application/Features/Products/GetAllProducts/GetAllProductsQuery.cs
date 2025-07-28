using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerceAPI.Application.Features.Products.GetAllProducts
{
    public record GetAllProductsQuery(int Page = 0, int Size = 10) : IRequest<GetAllProductsQueryResponse>;
    public record ProductDto(Guid Id, string Name, string Description, decimal Price, int Stock);
    public record GetAllProductsQueryResponse(List<ProductDto> Products, int TotalCount, int Page, int Size);
}
