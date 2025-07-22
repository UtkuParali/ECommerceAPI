using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerceAPI.Application.Features.Products.GetAllProducts
{
    public record GetAllProductsQuery() : IRequest<List<GetAllProductsQueryResponse>>;
    public record GetAllProductsQueryResponse(Guid Id, string Name, string Description, decimal Price, int Stock);
}
