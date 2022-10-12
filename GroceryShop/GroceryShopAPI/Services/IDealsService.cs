namespace GroceryShopAPI.Services
{
    using GroceryShopAPI.Data.Entities;
    using GroceryShopAPI.DTO;

    public interface IDealsService
    {
        Task<IEnumerable<DealViewDTO>> GetAll();

        Task<DealViewDTO> GetById(int id);

        Task<Deal> GetByName(string name);

        Task<DealViewDTO> Create(DealEntryDTO dealEntry);

        Task<DealViewDTO> Update(DealEntryDTO dealEntry);

        Task Delete(int id);
    }
}
