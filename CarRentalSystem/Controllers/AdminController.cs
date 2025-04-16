using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarRentalSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> Dashboard()
        {
            var data = await _adminService.GetDashboardDataAsync();
            return View(data);
        }

        public async Task<IActionResult> ManageUsers()
        {
            var users = await _adminService.GetAllUsersAsync();
            return View(users);
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            await _adminService.DeleteUserAsync(id);
            return RedirectToAction("ManageUsers");
        }
    }

}
