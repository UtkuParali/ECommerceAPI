using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerceAPI.Application.Features.Products.RemoveProduct
{
    public record RemoveProductCommand(Guid Id) : IRequest<RemoveProductCommandResponse>;
    public record RemoveProductCommandResponse(bool Success);
}
