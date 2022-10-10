namespace GroceryShopAPI.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public abstract class EntityBase : IEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
