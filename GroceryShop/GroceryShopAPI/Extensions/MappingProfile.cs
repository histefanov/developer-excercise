namespace GroceryShopAPI.Extensions
{
    using AutoMapper;
    using GroceryShopAPI.Data.Entities;
    using GroceryShopAPI.DTO;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewDTO>();

            CreateMap<ProductEntryDTO, Product>();

            CreateMap<Deal, DealViewDTO>();

            CreateMap<DealEntryDTO, Deal>();
        }
    }
}
