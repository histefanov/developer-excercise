namespace GroceryShopAPI.Services
{
    using Microsoft.EntityFrameworkCore;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using GroceryShopAPI.Data.Entities;
    using GroceryShopAPI.Data.Repositories;
    using GroceryShopAPI.DTO;
    using GroceryShopAPI.Common;

    public class DealsService : IDealsService
    {
        private readonly IRepository<Deal> _deals;
        private readonly IMapper _mapper;

        public DealsService(IRepository<Deal> deals, IMapper mapper)
        {
            _deals = deals;
            _mapper = mapper;   
        }
        public async Task<IEnumerable<DealViewDTO>> GetAll()
        {
            return await _deals
                .GetAll()
                .ProjectTo<DealViewDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<DealViewDTO> GetById(int id)
        {
            var deal = await _deals.GetById(id);

            if (deal == null)
            {
                throw new Exception(GlobalConstants.DealNotFound);
            }

            return _mapper.Map<DealViewDTO>(deal);
        }

        public async Task<DealViewDTO> Create(DealEntryDTO dealEntry)
        {
            var dealExists = await _deals.GetAll().AnyAsync(p => p.Name == dealEntry.Name);

            if (dealExists)
            {
                throw new Exception(GlobalConstants.DealExists);
            }

            ValidateDeal(dealEntry);

            var deal = _mapper.Map<Deal>(dealEntry);

            _deals.Insert(deal);
            await _deals.Save();

            return _mapper.Map<DealViewDTO>(deal);
        }

        public async Task<DealViewDTO> Update(DealEntryDTO dealEntry)
        {
            ValidateDeal(dealEntry);

            var deal = _mapper.Map<Deal>(dealEntry);

            _deals.Update(deal);
            await _deals.Save();

            return _mapper.Map<DealViewDTO>(deal);
        }

        public async Task Delete(int id)
        {
            var deal = await _deals.GetById(id);

            if (deal == null)
            {
                throw new Exception(GlobalConstants.DealNotFound);
            }

            _deals.Delete(deal);
            await _deals.Save();
        }

        private void ValidateDeal(DealEntryDTO dealEntry)
        {
            if (string.IsNullOrWhiteSpace(dealEntry.Name) || dealEntry.Name.Length > GlobalConstants.DealNameMaxLength)
            {
                throw new Exception(GlobalConstants.DealNameInvalid);
            }
        }
    }
}
