using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<IActionResult> Index()
        {
            var rolesString = HttpContext.Session.GetString("UserRoles");
            var roles = rolesString?.Split(','); // Convert back to a list of roles

            if (roles == null || !roles.Contains("User"))
            {
                return Unauthorized("Access Denied: User role required.");
            }

            var payments = await _paymentService.GetAllAsync();
            return View(payments);
        }

        public IActionResult Create(int rentalId)
        {
            var rolesString = HttpContext.Session.GetString("UserRoles");
            var roles = rolesString?.Split(','); // Convert back to a list of roles

            if (roles == null || !roles.Contains("User"))
            {
                return Unauthorized("Access Denied: User role required.");
            }

            var model = new PaymentModel { RentalId = rentalId };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PaymentModel model)
        {
            var rolesString = HttpContext.Session.GetString("UserRoles");
            var roles = rolesString?.Split(','); // Convert back to a list of roles

            if (roles == null || !roles.Contains("User"))
            {
                return Unauthorized("Access Denied: User role required.");
            }

            if (!ModelState.IsValid)
                return View(model);

            await _paymentService.AddAsync(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var rolesString = HttpContext.Session.GetString("UserRoles");
            var roles = rolesString?.Split(','); // Convert back to a list of roles

            if (roles == null || !roles.Contains("User"))
            {
                return Unauthorized("Access Denied: User role required.");
            }

            var payment = await _paymentService.GetByIdAsync(id);
            if (payment == null) return NotFound();
            return View(payment);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PaymentModel model)
        {
            var rolesString = HttpContext.Session.GetString("UserRoles");
            var roles = rolesString?.Split(','); // Convert back to a list of roles

            if (roles == null || !roles.Contains("User"))
            {
                return Unauthorized("Access Denied: User role required.");
            }

            if (!ModelState.IsValid)
                return View(model);

            await _paymentService.UpdateAsync(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var rolesString = HttpContext.Session.GetString("UserRoles");
            var roles = rolesString?.Split(','); // Convert back to a list of roles

            if (roles == null || !roles.Contains("User"))
            {
                return Unauthorized("Access Denied: User role required.");
            }

            var payment = await _paymentService.GetByIdAsync(id);
            if (payment == null) return NotFound();
            return View(payment);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rolesString = HttpContext.Session.GetString("UserRoles");
            var roles = rolesString?.Split(','); // Convert back to a list of roles

            if (roles == null || !roles.Contains("User"))
            {
                return Unauthorized("Access Denied: User role required.");
            }

            await _paymentService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var rolesString = HttpContext.Session.GetString("UserRoles");
            var roles = rolesString?.Split(','); // Convert back to a list of roles

            if (roles == null || !roles.Contains("User"))
            {
                return Unauthorized("Access Denied: User role required.");
            }

            var payment = await _paymentService.GetByIdAsync(id);
            if (payment == null) return NotFound();
            return View(payment);
        }
    }
}
