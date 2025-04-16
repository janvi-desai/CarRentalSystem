using CarRentalSystem.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers
{
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Profile()
        {
            var email = User.Identity?.Name!;
            var profile = await _userService.GetUserProfileAsync(email);
            return View(profile);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(string newName)
        {
            var email = User.Identity?.Name!;
            await _userService.UpdateUserNameAsync(email, newName);
            return RedirectToAction("Profile");
        }
    }

}
