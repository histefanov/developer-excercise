using GroceryShopAPI.DTO;
using GroceryShopAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GroceryShopAPI.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly ProductsService _productsService;

        public ProductsController(ProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewDTO>>> GetAll()
        {
            var products = await _productsService.GetAll();

            return Ok(products);
        }

        [HttpGet]
        public async Task<ActionResult<ProductViewDTO>> Get(int id)
        {
            return await _productsService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<ProductViewDTO>> Create(ProductEntryDTO productEntry)
        {
            var product = await _productsService.Create(productEntry);

            return CreatedAtAction("GetAll", new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductViewDTO>> Update(int id, ProductEntryDTO productEntry)
        {
            var product = await _productsService.Update(productEntry);

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productsService.Delete(id);

            return NoContent();
        }
    }
}
