using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Domain;
using MediatR;
using ECommerceAPI.Application.Repositories;
using Microsoft.Extensions.Logging;

namespace ECommerceAPI.Application.Features.Products.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<CreateProductCommandHandler> _logger;

        public CreateProductCommandHandler(IProductRepository productRepository, ILogger<CreateProductCommandHandler> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler: Yeni ürün domain nesnesi oluşturuluyor. İsim: {ProductName}", request.Name);
            var newProduct = new Product(
                request.Name,
                request.Description,
                request.Price,
                request.Stock);

            _logger.LogInformation("Handler: Ürün veritabanına ekleniyor.");
            await _productRepository.AddAsync(newProduct,cancellationToken);

            _logger.LogInformation("Handler: Ürün {ProductId} başarıyla eklendi.", newProduct.Id);
            var response = new CreateProductCommandResponse(
                newProduct.Id,
                newProduct.Name,
                newProduct.Description,
                newProduct.Price,
                newProduct.Stock);

            return response;
        }
    }
}
