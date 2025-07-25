using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerceAPI.Application.Features.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, string Description, decimal Price, int Stock) : IRequest<UpdateProductCommandResponse>;
    public record UpdateProductCommandResponse(Guid Id, string Name, string Description, decimal Price, int Stock);
}
