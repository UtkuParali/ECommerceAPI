using System.Threading;
using System.Threading.Tasks;
using ECommerceAPI.Application.Exceptions;
using ECommerceAPI.Application.Repositories;
using MediatR;

namespace ECommerceAPI.Application.Features.Products.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate = await _productRepository.GetByIdAsync(request.Id,cancellationToken);
            if (productToUpdate == null)
            {
                throw new ProductNotFoundException(request.Id);
            }

            productToUpdate.Update(request.Name, request.Description, request.Price, request.Stock);

            var updatedProduct = await _productRepository.UpdateAsync(productToUpdate, cancellationToken);

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
