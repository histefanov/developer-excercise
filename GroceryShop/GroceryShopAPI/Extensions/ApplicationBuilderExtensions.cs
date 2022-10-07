namespace GroceryShopAPI.Extensions
{
    using Microsoft.EntityFrameworkCore;
    using GroceryShopAPI.Data;
    using GroceryShopAPI.Data.Entities;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder InitializeDatabase(
            this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            
            var context = scopedServices.ServiceProvider.GetRequiredService<ShopDbContext>();

            context.Database.Migrate();
            SeedProducts(context);
            SeedDeals(context);
            SeedProductDeals(context);

            return app;
        }

        private static void SeedProducts(ShopDbContext context)
        {
            if (!context.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product
                    {
                        Name = "apple",
                        Price = 50
                    },
                    new Product
                    {
                        Name = "banana",
                        Price = 40
                    },
                    new Product
                    {
                        Name = "tomato",
                        Price = 30
                    },
                    new Product
                    {
                        Name = "potato",
                        Price = 26
                    }
                };

                foreach (var product in products)
                {
                    context.Products.Add(product);
                }

                context.SaveChanges();
            }
        }

        private static void SeedDeals(ShopDbContext context)
        {
            if (!context.Deals.Any())
            {
                var deals = new List<Deal>
                {
                    new Deal { Name = "2 for 3" },
                    new Deal { Name = "buy 1 get 1 half price" },
                };

                foreach (var deal in deals)
                {
                    context.Deals.Add(deal);
                }

                context.SaveChanges();
            }
        }

        private static void SeedProductDeals(ShopDbContext context)
        {
            if (!context.ProductDeals.Any())
            {
                var productDeals = new List<ProductDeal>
                {
                    new ProductDeal
                    {
                        ProductId = 1,
                        DealId = 1
                    },
                    new ProductDeal
                    {
                        ProductId = 2,
                        DealId = 1
                    },
                    new ProductDeal
                    {
                        ProductId = 3,
                        DealId = 1
                    },
                    new ProductDeal
                    {
                        ProductId = 4,
                        DealId = 2
                    },
                };

                foreach (var productDeal in productDeals)
                {
                    context.ProductDeals.Add(productDeal);
                }

                context.SaveChanges();
            }
        }
    }
}
