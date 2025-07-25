using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerceAPI.Application.Features.Products.GetProductById
{
    public record GetProductByIdQuery(Guid Id) : IRequest<GetProductByIdQueryResponse>;
    public record GetProductByIdQueryResponse(Guid Id, string Name, string Description, decimal Price, int Stock);
}
