using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            var rolesString = HttpContext.Session.GetString("UserRoles");
            var roles = rolesString?.Split(','); // Convert back to a list of roles

            if (roles == null || !roles.Contains("Admin") && !roles.Contains("User"))
            {
                return Unauthorized("Access Denied.");
            }
            ViewData["Title"] = "Dashboard";
            return View();
        }
    }
}
