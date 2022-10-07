namespace GroceryShopAPI.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Deal : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<ProductDeal> ProductDeals { get; set; } = new HashSet<ProductDeal>();
    }
}
