using GroceryShopAPI.DTO;
using GroceryShopAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GroceryShopAPI.Controllers
{
    public class DealsController : BaseApiController
    {
        private readonly IDealsService _dealsService;

        public DealsController(IDealsService dealsService)
        {
            _dealsService = dealsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DealViewDTO>>> GetAll()
        {
            var deals = await _dealsService.GetAll();

            return Ok(deals);
        }

        [HttpGet]
        public async Task<ActionResult<DealViewDTO>> Get(int id)
        {
            return await _dealsService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<DealViewDTO>> Create(DealEntryDTO dealEntry)
        {
            var deal = await _dealsService.Create(dealEntry);

            return CreatedAtAction("GetAll", new { id = deal.Id }, deal);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DealViewDTO>> Update(int id, DealEntryDTO dealEntry)
        {
            var deal = await _dealsService.Update(dealEntry);

            return Ok(deal);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _dealsService.Delete(id);

            return NoContent();
        }
    }
}
