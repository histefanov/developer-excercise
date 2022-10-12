namespace GroceryShopAPI.DTO
{
    public class ProductEntryDTO
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; }

        public string[] ProductDeals { get; set; } 
    }
}
