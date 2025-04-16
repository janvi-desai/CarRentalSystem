using CarRentalSystem.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers
{

    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Profile()
        {
            var rolesString = HttpContext.Session.GetString("UserRoles");
            var roles = rolesString?.Split(','); // Convert back to a list of roles

            if (roles == null || !roles.Contains("User"))
            {
                return Unauthorized("Access Denied: User role required.");
            }
            var email = User.Identity?.Name!;
            var profile = await _userService.GetUserProfileAsync(email);
            return View(profile);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(string newName)
        {
            var rolesString = HttpContext.Session.GetString("UserRoles");
            var roles = rolesString?.Split(','); // Convert back to a list of roles

            if (roles == null || !roles.Contains("User"))
            {
                return Unauthorized("Access Denied: User role required.");
            }
            var email = User.Identity?.Name!;
            await _userService.UpdateUserNameAsync(email, newName);
            return RedirectToAction("Profile");
        }
    }

}
