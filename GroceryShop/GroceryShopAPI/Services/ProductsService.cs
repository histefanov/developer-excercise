namespace GroceryShopAPI.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using GroceryShopAPI.Common;
    using GroceryShopAPI.Data.Entities;
    using GroceryShopAPI.Data.Repositories;
    using GroceryShopAPI.DTO;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class ProductsService : IProductsService
    {
        private readonly IRepository<Product> _products;
        private readonly IDealsService _dealsService;
        private readonly IMapper _mapper;

        public ProductsService(IRepository<Product> products, IMapper mapper, IDealsService dealsService)
        {
            _products = products;
            _dealsService = dealsService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductViewDTO>> GetAll()
        {
            return await _products
                .GetAll()
                .ProjectTo<ProductViewDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<ProductViewDTO> GetById(int id)
        {
            var product = await _products.GetById(id);

            if (product == null)
            {
                throw new Exception(GlobalConstants.ProductNotFound);
            }

            return _mapper.Map<ProductViewDTO>(product);
        }

        public async Task<ProductViewDTO> Create(ProductEntryDTO productEntry)
        {
            var productExists = await _products.GetAll().AnyAsync(p => p.Name == productEntry.Name);

            if (productExists)
            {
                throw new Exception(GlobalConstants.ProductExists);
            }

            ValidateProduct(productEntry);

            var product = _mapper.Map<Product>(productEntry);

            AddProductDeals(product, productEntry.ProductDeals);

            _products.Insert(product);
            await _products.Save();

            return _mapper.Map<ProductViewDTO>(product);
        }

        public async Task<ProductViewDTO> Update(ProductEntryDTO productEntry)
        {
            ValidateProduct(productEntry);

            var product = _mapper.Map<Product>(productEntry);

            await AddProductDeals(product, productEntry.ProductDeals);

            _products.Update(product);
            await _products.Save();

            return _mapper.Map<ProductViewDTO>(product);
        }

        public async Task Delete(int id)
        {
            var product = await _products.GetById(id);

            if (product == null)
            {
                throw new Exception(GlobalConstants.ProductNotFound);
            }

            _products.Delete(product);
            await _products.Save();
        }

        private async Task AddProductDeals(Product product, string[] dealNames)
        {
            foreach (var dealName in dealNames)
            {
                var deal = await _dealsService.GetByName(dealName);

                if (deal == null)
                {
                    throw new Exception(GlobalConstants.DealNotFound);
                }

                if (product.ProductDeals.Any(pd => pd.Deal.Name == dealName))
                {
                    throw new Exception(GlobalConstants.DealExists);
                }

                var productDeal = new ProductDeal
                {
                    Deal = deal,
                    Product = product
                };

                product.ProductDeals.Add(productDeal);
            }
        }

        private void ValidateProduct(ProductEntryDTO productEntry)
        {
            if (string.IsNullOrWhiteSpace(productEntry.Name) 
                || productEntry.Name.Length > GlobalConstants.ProductNameMaxLength)
            {
                throw new Exception(GlobalConstants.ProductNameInvalid);
            }

            if (productEntry.Price <= 0)
            {
                throw new Exception(GlobalConstants.ProductPriceInvalid);
            }
        }
    }
}
