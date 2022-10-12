namespace GroceryShopAPI.Services
{
    using GroceryShopAPI.DTO;

    public interface IDealsService
    {
        Task<IEnumerable<DealViewDTO>> GetAll();

        Task<DealViewDTO> GetById(int id);

        Task<DealViewDTO> Create(DealEntryDTO dealEntry);

        Task<DealViewDTO> Update(DealEntryDTO dealEntry);

        Task Delete(int id);
    }
}
