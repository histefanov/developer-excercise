namespace GroceryShopAPI.Data.Entities
{
    public class ProductDeal
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int DealId { get; set; }

        public Deal Deal { get; set; }
    }
}
