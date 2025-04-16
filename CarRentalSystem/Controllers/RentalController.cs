// RentalController.cs
using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers
{
    [Authorize]
    public class RentalController : Controller
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var rentals = await _rentalService.GetAllRentalsAsync();
            return View(rentals);
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> MyRentals(string userId)
        {
            var rentals = await _rentalService.GetAllRentalsAsync();
            return View("MyRentals", rentals.Where(r => r.UserId == userId));
        }

        [Authorize(Roles = "User")]
        public IActionResult Create(int carId)
        {
            return View(new RentalModel { CarId = carId, RentDate = DateTime.Today, ReturnDate = DateTime.Today.AddDays(1) });
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Create(RentalModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _rentalService.CreateRentalAsync(model);
            return RedirectToAction("MyRentals", new { userId = model.UserId });
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> Return(int id)
        {
            var rental = await _rentalService.GetRentalByIdAsync(id);
            if (rental == null) return NotFound();
            return View(rental);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Return(RentalModel model)
        {
            model.Status = "Returned";
            await _rentalService.UpdateRentalAsync(model);
            return RedirectToAction("MyRentals", new { userId = model.UserId });
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> Cancel(int id)
        {
            var rental = await _rentalService.GetRentalByIdAsync(id);
            if (rental == null) return NotFound();
            return View(rental);
        }

        [HttpPost, ActionName("Cancel")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CancelConfirmed(int id)
        {
            await _rentalService.DeleteRentalAsync(id);
            return RedirectToAction("MyRentals", new { userId = User.Identity.Name });
        }
    }
}
