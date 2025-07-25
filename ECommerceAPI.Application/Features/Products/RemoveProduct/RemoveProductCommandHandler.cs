using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.Exceptions;
using ECommerceAPI.Application.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ECommerceAPI.Application.Features.Products.RemoveProduct
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, RemoveProductCommandResponse>
    {

        private readonly IProductRepository _productRepository;
        private readonly ILogger<RemoveProductCommandHandler> _logger;

        public RemoveProductCommandHandler(IProductRepository productRepository, ILogger<RemoveProductCommandHandler> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<RemoveProductCommandResponse> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler: Ürün {ProductId} Id ile silinmek üzere sorgulanıyor.");
            var productToRemove = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

            if (productToRemove == null)
            {
                _logger.LogInformation("Handler: Ürün {ProductId} Id ile bulunamadı, silme işlemi başarısız.", request.Id);
                throw new ProductNotFoundException(request.Id);
            }

            _logger.LogInformation("Handler: Ürün {ProductId} veritabanından siliniyor.");
            var removedProduct = await _productRepository.RemoveAsync(productToRemove, cancellationToken);
           
            _logger.LogInformation("Handler: Ürün {ProductId} başarıyla silindi. Başarı durumu: {Success}", request.Id, removedProduct != null);
            return new RemoveProductCommandResponse(removedProduct != null);
        }
    }
}
