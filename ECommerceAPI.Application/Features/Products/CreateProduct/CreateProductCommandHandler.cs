using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Domain;
using MediatR;
using ECommerceAPI.Application.Repositories;

namespace ECommerceAPI.Application.Features.Products.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
    {

        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<CreateProductCommandResponse> Handle(
            CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = new Product(
                request.Name,
                request.Description,
                request.Price,
                request.Stock);

            await _productRepository.AddAsync(newProduct);

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
