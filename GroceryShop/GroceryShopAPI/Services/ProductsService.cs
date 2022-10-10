namespace GroceryShopAPI.Services
{
    using GroceryShopAPI.Data.Entities;
    using GroceryShopAPI.Data.Repositories;


    public class ProductsService
    {
        private readonly IRepository<Product> _products;

        public ProductsService(IRepository<Product> products)
        {
            _products = products;   
        }
    }
}
