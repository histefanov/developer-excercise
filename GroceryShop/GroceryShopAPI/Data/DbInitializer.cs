namespace GroceryShopAPI.Data
{
    using GroceryShopAPI.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public static class DbInitializer
    {
        public static async Task Initialize(ShopDbContext context)
        {
            await SeedCategories(context);
            await SeedProducts(context);
            await SeedDeals(context);
            await SeedProductDeals(context);
        }

        private static async Task SeedCategories(ShopDbContext context)
        {
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Fruits" },
                    new Category { Name = "Vegetables"}
                };

                foreach (var category in categories)
                {
                    await context.Categories.AddAsync(category);
                }

                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedProducts(ShopDbContext context)
        {
            if (!context.Products.Any())
            {
                var fruitsCategory = await context.Categories.FirstOrDefaultAsync(c => c.Name == "Fruits");
                var vegetablesCategory = await context.Categories.FirstOrDefaultAsync(c => c.Name == "Vegetables");

                var products = new List<Product>
                {
                    new Product
                    {
                        Name = "apple",
                        Price = 50,
                        Category = fruitsCategory
                    },
                    new Product
                    {
                        Name = "banana",
                        Price = 40,
                        Category = fruitsCategory
                    },
                    new Product
                    {
                        Name = "tomato",
                        Price = 30,
                        // For the sake of client convenience, we can say that tomatoes are vegetables =D
                        Category = vegetablesCategory
                    },
                    new Product
                    {
                        Name = "potato",
                        Price = 26,
                        Category = vegetablesCategory
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
