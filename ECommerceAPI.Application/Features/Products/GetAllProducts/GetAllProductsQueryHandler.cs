using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.Repositories;
using MediatR;

namespace ECommerceAPI.Application.Features.Products.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<GetAllProductsQueryResponse>>
    {

        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<GetAllProductsQueryResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync(cancellationToken);

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
