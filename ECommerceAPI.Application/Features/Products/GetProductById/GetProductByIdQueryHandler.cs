using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ECommerceAPI.Application.Repositories;
using MediatR;
using ECommerceAPI.Application.Exceptions;

namespace ECommerceAPI.Application.Features.Products.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResponse>
    {

        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
            if (product == null)
            {
                throw new ProductNotFoundException(request.Id);
            }

            return new GetProductByIdQueryResponse(
                product.Id,
                product.Name,
                product.Description,
                product.Price,
                product.Stock
                );
        }
    }
}
