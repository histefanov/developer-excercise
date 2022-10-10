using GroceryShopAPI.Services;

namespace GroceryShopAPI.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly ProductsService _productsService;

        public ProductsController(ProductsService productsService)
        {
            _productsService = productsService;
        }
    }
}
