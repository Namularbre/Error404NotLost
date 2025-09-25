using Error404NotLost_BLL.Services;
using Error404NotLost_DAL.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Error404NotLost_WEBASP.Controllers
{
    [Authorize($"{nameof(ERoles.Moderator)},{nameof(ERoles.Moderator)}")]
    public class UserController : BaseController
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            List<IdentityUser> users = await _userService.GetUsers();

            return View(users);
        }

        public async Task<IActionResult> Delete(string id)
        {
            IdentityUser? user = await _userService.GetUserById(id);
            if (user != null)
            {
                await _userService.DeleteUserById(id);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
