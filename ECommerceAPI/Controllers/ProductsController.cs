using Microsoft.AspNetCore.Mvc;
using MediatR;
using ECommerceAPI.Application.Features.Products.CreateProduct;
using ECommerceAPI.Application.Features.Products.GetAllProducts;
using Asp.Versioning;
using ECommerceAPI.Application.Features.Products.GetProductById;
using ECommerceAPI.Application.Features.Products.UpdateProduct;
using ECommerceAPI.Application.Features.Products.RemoveProduct;

namespace ECommerceAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var response = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(Guid id)
        {
            var repsonse = await _mediator.Send(new RemoveProductCommand(id));
            return Ok(repsonse);
        }
    }
}
