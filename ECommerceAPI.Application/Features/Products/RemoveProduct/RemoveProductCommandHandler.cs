using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.Exceptions;
using ECommerceAPI.Application.Repositories;
using MediatR;

namespace ECommerceAPI.Application.Features.Products.RemoveProduct
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, RemoveProductCommandResponse>
    {

        private readonly IProductRepository _productRepository;

        public RemoveProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<RemoveProductCommandResponse> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var productToRemove = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
            if (productToRemove == null)
            {
                throw new ProductNotFoundException(request.Id);
            }
            var removedProduct = await _productRepository.RemoveAsync(productToRemove, cancellationToken);

            return new RemoveProductCommandResponse(removedProduct != null);
        }
    }
}
