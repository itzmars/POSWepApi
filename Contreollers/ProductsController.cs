using Microsoft.AspNetCore.Mvc;
using POSWebApi.Models;
using POSWebApi.Repositories.IRepositories;

namespace POSWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepo;

        public ProductsController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        //Get: products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepo.GetAllProductsAsync();
            return Ok(products);
        }

        //Get: products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            var product = await _productRepo.GetProductByIdAsync(id);
            return Ok(product);
        }


        //Post: products
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            await _productRepo.CreateProductAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        //Put: products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] Product product)
        {
            var existingProduct = await _productRepo.GetProductByIdAsync(id);
            if (existingProduct == null) { 
                return NotFound();
            }
            product.Id = id;
            await _productRepo.UpdateProductAsync(product);

            return NoContent();
        }

        //Delete: products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id){
            var existingProduct = await _productRepo.GetProductByIdAsync(id);
            if (existingProduct == null) { 
                return NotFound();
            }
            
            await _productRepo.DeleteProductAsync(id);
            return NoContent();
        }

    }
}