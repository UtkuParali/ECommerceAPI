using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ECommerceAPI.Application.Features.Products.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler <GetAllProductsQuery, GetAllProductsQueryResponse>
    {

        private readonly IProductRepository _productRepository;
        private readonly ILogger<GetAllProductsQueryHandler> _logger;

        public GetAllProductsQueryHandler(IProductRepository productRepository, ILogger<GetAllProductsQueryHandler> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler: Tüm ürünler sayfa {Page}, boyut {Size} ile sorgulanıyor.", request.Page, request.Size);

            var totalCount = await _productRepository.GetTotalProductCountAsync(cancellationToken);
            
            var products = await _productRepository.GetAllAsync(request.Page, request.Size, cancellationToken);

            var productDtos = products.Select(p => new ProductDto(p.Id, p.Name, p.Description, p.Price, p.Stock)).ToList();
            
            _logger.LogInformation("Handler: Sayfa {Page} için {ProductCount} ürün getirildi. Toplam ürün: {TotalCount}", request.Page, productDtos.Count, totalCount);

            return new GetAllProductsQueryResponse(productDtos, totalCount, request.Page, request.Size);
        }
    }
}
