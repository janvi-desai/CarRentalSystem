using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarRentalSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> Dashboard()
        {
            var rolesString = HttpContext.Session.GetString("UserRoles");
            var roles = rolesString?.Split(','); // Convert back to a list of roles

            if (roles == null || !roles.Contains("Admin"))
            {
                return Unauthorized("Access Denied: Admin role required.");
            }

            var data = await _adminService.GetDashboardDataAsync();
            return View(data);
        }

        public async Task<IActionResult> ManageUsers()
        {
            var rolesString = HttpContext.Session.GetString("UserRoles");
            var roles = rolesString?.Split(','); // Convert back to a list of roles

            if (roles == null || !roles.Contains("Admin"))
            {
                return Unauthorized("Access Denied: Admin role required.");
            }

            var users = await _adminService.GetAllUsersAsync();
            return View(users);
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var rolesString = HttpContext.Session.GetString("UserRoles");
            var roles = rolesString?.Split(','); // Convert back to a list of roles

            if (roles == null || !roles.Contains("Admin"))
            {
                return Unauthorized("Access Denied: Admin role required.");
            }

            await _adminService.DeleteUserAsync(id);
            return RedirectToAction("ManageUsers");
        }
    }

}
