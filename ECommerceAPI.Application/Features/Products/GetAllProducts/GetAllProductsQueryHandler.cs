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
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<GetAllProductsQueryResponse>>
    {

        private readonly IProductRepository _productRepository;
        private readonly ILogger<GetAllProductsQueryHandler> _logger;

        public GetAllProductsQueryHandler(IProductRepository productRepository, ILogger<GetAllProductsQueryHandler> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<List<GetAllProductsQueryResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler: Tüm ürünler veritabanından alınıyor.");
            var products = await _productRepository.GetAllAsync(cancellationToken);
            
            _logger.LogInformation("Handler: Tüm ürünler başarıyla getirildi.");
            var response = products.Select(p => new GetAllProductsQueryResponse(
                p.Id,
                p.Name,
                p.Description,
                p.Price,
                p.Stock
                )).ToList();

            return response;
        }
    }
}
