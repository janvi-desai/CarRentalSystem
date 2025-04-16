using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers
{
    [Authorize]
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

        // ADMIN VIEW: List all cars
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminIndex()
        {
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
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CarModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _carService.AddAsync(model);
            return RedirectToAction(nameof(AdminIndex));
        }

        // GET: Car/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var car = await _carService.GetByIdAsync(id);
            if (car == null)
                return NotFound();

            return View(car);
        }

        // POST: Car/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, CarModel model)
        {
            if (id != model.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(model);

            await _carService.UpdateAsync(model);
            return RedirectToAction(nameof(AdminIndex));
        }

        // GET: Car/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var car = await _carService.GetByIdAsync(id);
            if (car == null)
                return NotFound();

            return View(car);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _carService.DeleteAsync(id);
            return RedirectToAction(nameof(AdminIndex));
        }

        // ADMIN: Mark car as rented
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> MarkAsRented(int id)
        {
            await _carService.MarkAsRentedAsync(id);
            return RedirectToAction(nameof(AdminIndex));
        }
    }
}
