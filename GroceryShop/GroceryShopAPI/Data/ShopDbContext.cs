namespace GroceryShopAPI.Data
{
    using Microsoft.EntityFrameworkCore;
    using GroceryShopAPI.Data.Entities;

    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Deal> Deals { get; set; }

        public DbSet<Bill> Bills { get; set; }

        public DbSet<ProductDeal> ProductDeals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<ProductDeal>()
                .HasKey(pd => new { pd.ProductId, pd.DealId });

            builder.Entity<ProductDeal>()
                .HasOne(pd => pd.Product)
                .WithMany(p => p.ProductDeals)
                .HasForeignKey(pd => pd.ProductId);

            builder.Entity<ProductDeal>()
                .HasOne(pd => pd.Deal)
                .WithMany(d => d.ProductDeals)
                .HasForeignKey(pd => pd.DealId);
        }
    }
}
