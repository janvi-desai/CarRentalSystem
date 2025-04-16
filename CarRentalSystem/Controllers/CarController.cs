using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers
{
    //[Authorize]
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        // USER VIEW: List available cars
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var availableCars = await _carService.GetAvailableCarsAsync();
            return View(availableCars);
        }


        [HttpGet]
        // ADMIN VIEW: List all cars
        public async Task<IActionResult> AdminIndex()
        {
            var rolesString = HttpContext.Session.GetString("UserRoles");
            var roles = rolesString?.Split(','); // Convert back to a list of roles

            if (roles == null || !roles.Contains("Admin"))
            {
                return Unauthorized("Access Denied: Admin role required.");
            }

            // Proceed with action logic
            var cars = await _carService.GetAllAsync();
            return View(cars);
        }

        // GET: Car/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var car = await _carService.GetByIdAsync(id);
            if (car == null)
                return NotFound();

            return View(car);
        }

        // GET: Car/Create
        public IActionResult Create()
        {
            var rolesString = HttpContext.Session.GetString("UserRoles");
            var roles = rolesString?.Split(','); // Convert back to a list of roles

            if (roles == null || !roles.Contains("Admin"))
            {
                return Unauthorized("Access Denied: Admin role required.");
            }
            return View();
        }

        // POST: Car/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarModel car)
        {
            var rolesString = HttpContext.Session.GetString("UserRoles");
            var roles = rolesString?.Split(','); // Convert back to a list of roles

            if (roles == null || !roles.Contains("Admin"))
            {
                return Unauthorized("Access Denied: Admin role required.");
            }

            if (!ModelState.IsValid)
                return View(car);

            await _carService.AddAsync(car);
            return RedirectToAction(nameof(AdminIndex));
        }

        // GET: Car/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var rolesString = HttpContext.Session.GetString("UserRoles");
            var roles = rolesString?.Split(','); // Convert back to a list of roles

            if (roles == null || !roles.Contains("Admin"))
            {
                return Unauthorized("Access Denied: Admin role required.");
            }
            var car = await _carService.GetByIdAsync(id);
            if (car == null)
                return NotFound();

            return View(car);
        }

        // POST: Car/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CarModel car)
        {
            var rolesString = HttpContext.Session.GetString("UserRoles");
            var roles = rolesString?.Split(','); // Convert back to a list of roles

            if (roles == null || !roles.Contains("Admin"))
            {
                return Unauthorized("Access Denied: Admin role required.");
            }

            if (id != car.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(car);

            await _carService.UpdateAsync(car);
            return RedirectToAction(nameof(AdminIndex));
        }

        // GET: Car/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var rolesString = HttpContext.Session.GetString("UserRoles");
            var roles = rolesString?.Split(','); // Convert back to a list of roles

            if (roles == null || !roles.Contains("Admin"))
            {
                return Unauthorized("Access Denied: Admin role required.");
            }

            var car = await _carService.GetByIdAsync(id);
            if (car == null)
                return NotFound();

            return View(car);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rolesString = HttpContext.Session.GetString("UserRoles");
            var roles = rolesString?.Split(','); // Convert back to a list of roles

            if (roles == null || !roles.Contains("Admin"))
            {
                return Unauthorized("Access Denied: Admin role required.");
            }

            await _carService.DeleteAsync(id);
            return RedirectToAction(nameof(AdminIndex));
        }

        // ADMIN: Mark car as rented
        [HttpPost]
        public async Task<IActionResult> MarkAsRented(int id)
        {
            var rolesString = HttpContext.Session.GetString("UserRoles");
            var roles = rolesString?.Split(','); // Convert back to a list of roles

            if (roles == null || !roles.Contains("Admin"))
            {
                return Unauthorized("Access Denied: Admin role required.");
            }

            await _carService.MarkAsRentedAsync(id);
            return RedirectToAction(nameof(AdminIndex));
        }
    }
}
