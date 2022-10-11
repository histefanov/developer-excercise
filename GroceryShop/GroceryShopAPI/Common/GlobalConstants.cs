namespace GroceryShopAPI.Common
{
    public static class GlobalConstants
    {
        public const string ProjectName = "GroceryShopAPI";

        public const string DefaultConnection = "DefaultConnection";
        public const string ClientUrl = "http://localhost:3000";

        public const string BaseControllerRoute = "api/[controller]";

        public const short ProductNameMaxLength = 100;
        public const string ProductNotFound = "Could not find a product with the provided ID.";
        public const string ProductNameInvalid = "Product name must be 1-100 characters long.";
        public const string ProductPriceInvalid = "Product price must be at least 1c.";
        public const string ProductExists = "A product with the given name already exists.";
    }
}
