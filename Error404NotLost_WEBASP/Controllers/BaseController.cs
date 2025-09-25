using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Error404NotLost_WEBASP.Controllers
{
    /// <summary>
    /// Base controller to provide common functionalities for all controllers
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// Get the current logged-in user's ID
        /// </summary>
        /// <returns></returns>
        protected string? GetCurrentUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);
        
    }
}
