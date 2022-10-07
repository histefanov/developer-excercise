namespace GroceryShopAPI.Data
{
    using GroceryShopAPI.Data.Entities;

    public static class DbInitializer
    {
        public static async Task Initialize(ShopDbContext context)
        {
            await SeedProducts(context);
            await SeedDeals(context);
            await SeedProductDeals(context);
        }

        private static async Task SeedProducts(ShopDbContext context)
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
                    await context.Products.AddAsync(product);
                }

                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedDeals(ShopDbContext context)
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
                    await context.Deals.AddAsync(deal);
                }

                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedProductDeals(ShopDbContext context)
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
                    await context.ProductDeals.AddAsync(productDeal);
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
