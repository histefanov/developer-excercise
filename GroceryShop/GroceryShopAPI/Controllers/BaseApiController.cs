namespace GroceryShopAPI.Controllers
{
    using GroceryShopAPI.Common;
    using GroceryShopAPI.Data.Entities;
    using GroceryShopAPI.Data.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [ApiController]
    [Route(GlobalConstants.BaseControllerRoute)]
    public abstract class BaseApiController : ControllerBase
    {
    }
}
