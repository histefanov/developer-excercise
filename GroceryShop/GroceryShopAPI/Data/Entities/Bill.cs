namespace GroceryShopAPI.Data.Entities
{
    public class Bill : EntityBase
    {
        public decimal TotalAmount { get; set; }

        public decimal Discount { get; set; }

        public decimal AmountWithDiscount { get; set; }
    }
}
