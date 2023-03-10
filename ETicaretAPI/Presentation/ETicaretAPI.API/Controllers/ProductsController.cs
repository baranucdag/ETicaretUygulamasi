using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var result = _productService.GetProducts();
            return Ok(result);
        }

        [HttpPost("AddRange")]
        public async Task<IActionResult> AddRangeAsync()
        {
             await _productService.AddRangeAsync();
            return Ok();
        }
    }
}
