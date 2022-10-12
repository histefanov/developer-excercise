namespace GroceryShopAPI.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using GroceryShopAPI.Common;

    public class Deal : EntityBase
    {
        [Required]
        [MaxLength(GlobalConstants.DealNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<ProductDeal> ProductDeals { get; set; } = new HashSet<ProductDeal>();
    }
}
