using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;
using CarRentalSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarRentalSystem.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthController(IAuthService authService, SignInManager<IdentityUser> signInManager)
        {
            _authService = authService;
            _signInManager = signInManager;
        }

        // GET: /Auth/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Auth/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            // Validate model state
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                // Ensure the role is valid (optional validation)
                if (string.IsNullOrWhiteSpace(model.Role))
                {
                    ModelState.AddModelError("", "Role is required.");
                    return View(model);
                }

                // Register the user using the AuthService
                var result = await _authService.RegisterAsync(model.Email, model.Password, model.Role);

                if (result.Succeeded)
                {
                    // Redirect to Login on success
                    return RedirectToAction("Login", "Auth");
                }

                // Handle errors from RegisterAsync
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            catch (Exception ex)
            {
                // Log unexpected errors (use a proper logging framework in production)
                Console.WriteLine($"Error during registration: {ex.Message}");

                ModelState.AddModelError("", "An unexpected error occurred. Please try again later.");
            }

            // Return the view with validation errors
            return View(model);
        }

        // GET: /Auth/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Auth/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _authService.LoginAsync(model.Email, model.Password);

            if (result.Succeeded)
            {
                // Store user email and roles in session
                HttpContext.Session.SetString("UserEmail", model.Email);
                var user = await _authService.GetUserByEmailAsync(model.Email);
                var roles = await _authService.GetUserRolesAsync(user);
                HttpContext.Session.SetString("UserRoles", string.Join(",", roles)); // Store roles as a comma-separated string

                if (roles.Contains("Admin"))
                    return RedirectToAction("AdminIndex", "Car");
                else
                    return RedirectToAction("Index", "Car");
            }

            ModelState.AddModelError("", "Invalid login attempt");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            // Clear session values
            HttpContext.Session.Remove("UserEmail");
            HttpContext.Session.Remove("UserRoles");
            // Alternatively: HttpContext.Session.Clear();

            return RedirectToAction("Login", "Auth");
        }

    }
}
