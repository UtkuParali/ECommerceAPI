using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ECommerceAPI.Application.Repositories;
using MediatR;
using ECommerceAPI.Application.Exceptions;
using Microsoft.Extensions.Logging;

namespace ECommerceAPI.Application.Features.Products.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResponse>
    {

        private readonly IProductRepository _productRepository;
        private readonly ILogger<GetProductByIdQueryHandler> _logger;

        public GetProductByIdQueryHandler(IProductRepository productRepository, ILogger<GetProductByIdQueryHandler> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler: Ürün {ProductId} Id ile veritabanında sorgulanıyor.", request.Id);
            var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

            if (product == null)
            {
                _logger.LogInformation("Handler: Ürün {ProductId} Id ile bulunamadı.",request.Id);
                throw new ProductNotFoundException(request.Id);
            }

            _logger.LogInformation("Handler: Ürün {ProductId} Id ile başarıyla getirildi.", product.Id);
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
