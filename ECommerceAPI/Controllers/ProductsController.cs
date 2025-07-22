using Microsoft.AspNetCore.Mvc;
using MediatR;
using ECommerceAPI.Application.Features.Products.CreateProduct;
using ECommerceAPI.Application.Features.Products.GetAllProducts;
using Asp.Versioning;

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

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
