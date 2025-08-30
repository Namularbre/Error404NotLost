using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Error404NotLost_WEBASP.Controllers
{
    public class BaseController : Controller
    {
        protected string? GetCurrentUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);
        
    }
}
