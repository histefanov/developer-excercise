namespace GroceryShopAPI.Data.Entities
{
    using GroceryShopAPI.Common;
    using System.ComponentModel.DataAnnotations;

    public class Product : EntityBase
    {
        [Required]
        [MaxLength(GlobalConstants.ProductNameMaxLength)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<ProductDeal> ProductDeals { get; set; } = new HashSet<ProductDeal>();
    }
}
