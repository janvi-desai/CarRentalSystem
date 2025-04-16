using CarRentalSystem.Data;
using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


public class SystemSettingController : Controller
{
    private readonly ISystemSettingService _service;

    public SystemSettingController(ISystemSettingService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var rolesString = HttpContext.Session.GetString("UserRoles");
        var roles = rolesString?.Split(','); // Convert back to a list of roles

        if (roles == null || !roles.Contains("Admin"))
        {
            return Unauthorized("Access Denied: Admin role required.");
        }
        var settings = await _service.GetAllAsync();
        return View(settings);
    }

    public async Task<IActionResult> Edit(string key)
    {
        var rolesString = HttpContext.Session.GetString("UserRoles");
        var roles = rolesString?.Split(','); // Convert back to a list of roles

        if (roles == null || !roles.Contains("Admin"))
        {
            return Unauthorized("Access Denied: Admin role required.");
        }
        var setting = await _service.GetByKeyAsync(key);
        if (setting == null) return NotFound();
        return View(setting);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(SystemSettingModel model)
    {
        var rolesString = HttpContext.Session.GetString("UserRoles");
        var roles = rolesString?.Split(','); // Convert back to a list of roles

        if (roles == null || !roles.Contains("Admin"))
        {
            return Unauthorized("Access Denied: Admin role required.");
        }
        if (!ModelState.IsValid)
            return View(model);

        await _service.AddOrUpdateAsync(model);
        return RedirectToAction("Index");
    }

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

    [HttpPost]
    public async Task<IActionResult> Create(SystemSettingModel model)
    {
        var rolesString = HttpContext.Session.GetString("UserRoles");
        var roles = rolesString?.Split(','); // Convert back to a list of roles

        if (roles == null || !roles.Contains("Admin"))
        {
            return Unauthorized("Access Denied: Admin role required.");
        }
        if (!ModelState.IsValid)
            return View(model);

        await _service.AddOrUpdateAsync(model);
        return RedirectToAction("Index");
    }
}
