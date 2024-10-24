using System.Threading.Tasks;
using HelloWorldCrudDynamoDb.Models;
using HelloWorldCrudDynamoDb.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldCrudDynamoDb.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController: ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await _service.SaveProductAsync(product);
            
            return Ok("Product created successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _service.GetProductByIdAsync(id);

            if (product == null) 
                return NotFound();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteProductAsync(id);
            return Ok("Product deleted successfully");
        }
    }
}