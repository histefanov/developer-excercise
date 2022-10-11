namespace GroceryShopAPI.Services
{
    using GroceryShopAPI.DTO;

    public interface IProductsService
    {
        Task<IEnumerable<ProductViewDTO>> GetAll();

        Task<ProductViewDTO> GetById(int id);

        Task<ProductViewDTO> Create(ProductEntryDTO productCreateDTO);

        Task<ProductViewDTO> Update(ProductEntryDTO newProduct);

        Task Delete(int id);
    }
}
