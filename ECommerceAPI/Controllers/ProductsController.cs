using Microsoft.AspNetCore.Mvc;
using MediatR;
using ECommerceAPI.Application.Features.Products.CreateProduct;
using ECommerceAPI.Application.Features.Products.GetAllProducts;
using Asp.Versioning;
using ECommerceAPI.Application.Features.Products.GetProductById;
using ECommerceAPI.Application.Features.Products.UpdateProduct;
using ECommerceAPI.Application.Features.Products.RemoveProduct;
using Microsoft.Extensions.Logging;

namespace ECommerceAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IMediator mediator, ILogger<ProductsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] int page = 0, [FromQuery] int size = 10)
        {
            _logger.LogInformation("Tüm ürünler listesi isteniyor (Sayfa: {Page}, Boyut: {Size}).", page,size);
            var query = new GetAllProductsQuery(page, size);
            var response = await _mediator.Send(query);
            _logger.LogInformation("Tüm ürünler başarıyla listelendi. Toplam: {TotalCount}",response.TotalCount);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            _logger.LogInformation("Ürün {ProductId} Id ile sorgulanıyor.", id);
            var response = await _mediator.Send(new GetProductByIdQuery(id));
            _logger.LogInformation("Ürün {ProductId} Id ile başarıyla getirildi.",id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            _logger.LogInformation("Yeni ürün oluşturma isteği anlındı: {ProductName}", command.Name);
            var response = await _mediator.Send(command);
            _logger.LogInformation("Ürün {ProductId} başarıyla oluşturuldu", response.Id);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            _logger.LogInformation("Ürün {ProductId} güncelleme isteği alındı.",command.Id);
            var response = await _mediator.Send(command);
            _logger.LogInformation("Ürün {ProductId} başarıyla güncellendi.", response.Id);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(Guid id)
        {
            _logger.LogInformation("Ürün {ProductId} silme isteği alındı.", id);
            var response = await _mediator.Send(new RemoveProductCommand(id));
            _logger.LogInformation("Ürün {ProductId} başarıyla silindi. Başaru durumu: {Success}", id, response.Success);
            return Ok(response);
        }
    }
}
