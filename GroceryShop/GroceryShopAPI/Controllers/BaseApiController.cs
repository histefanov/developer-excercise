namespace GroceryShopAPI.Controllers
{
    using GroceryShopAPI.Common;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route(GlobalConstants.BaseControllerRoute)]
    public abstract class BaseApiController : ControllerBase
    {
    }
}
