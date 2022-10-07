namespace GroceryShopAPI.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Product : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<ProductDeal> ProductDeals { get; set; } = new HashSet<ProductDeal>();
    }
}
