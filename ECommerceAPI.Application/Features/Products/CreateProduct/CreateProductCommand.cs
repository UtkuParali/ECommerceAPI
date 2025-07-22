using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerceAPI.Application.Features.Products.CreateProduct
{
    public record CreateProductCommand(string Name, string Description, decimal Price, int Stock) : 
        IRequest<CreateProductCommandResponse>;
    public record CreateProductCommandResponse(Guid Id, string Name, string Description, decimal Price, int Stock);
}
