namespace GroceryShopAPI.Services
{
    using GroceryShopAPI.DTO;

    public interface IProductsService
    {
        Task<IEnumerable<ProductViewDTO>> GetAll();

        Task<ProductViewDTO> GetById(int id);

        Task<ProductViewDTO> Create(ProductEntryDTO productEntry);

        Task<ProductViewDTO> Update(ProductEntryDTO productEntry);

        Task Delete(int id);
    }
}
