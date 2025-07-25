using System.Threading;
using System.Threading.Tasks;
using ECommerceAPI.Application.Exceptions;
using ECommerceAPI.Application.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ECommerceAPI.Application.Features.Products.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<UpdateProductCommandHandler> _logger;

        public UpdateProductCommandHandler(IProductRepository productRepository, ILogger<UpdateProductCommandHandler> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler: Ürün {ProductId} Id ile güncellenmek üzere sorgulanıyor.", request.Id);
            var productToUpdate = await _productRepository.GetByIdAsync(request.Id,cancellationToken);
            
            if (productToUpdate == null)
            {
                _logger.LogInformation("Handler: Ürün {ProductId} Id ile bulunamadı, güncelleme başarısız.", request.Id);
                throw new ProductNotFoundException(request.Id);
            }

            _logger.LogInformation("Handler: Ürün {ProductId} detayları güncelleniyor.", request.Id);
            productToUpdate.Update(request.Name, request.Description, request.Price, request.Stock);

            _logger.LogInformation("Handler: Güncellenmiş ürün {ProductId} veritabanına kaydediliyor.", request.Id);
            var updatedProduct = await _productRepository.UpdateAsync(productToUpdate, cancellationToken);

            _logger.LogInformation("Handler: Ürün {ProductId} başarıyla güncellendi.", updatedProduct.Id);
            return new UpdateProductCommandResponse(
                updatedProduct.Id,
                updatedProduct.Name,
                updatedProduct.Description,
                updatedProduct.Price,
                updatedProduct.Stock
                );
        }
    }
}
