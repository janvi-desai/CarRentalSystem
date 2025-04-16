using CarRentalSystem.Data;
using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Admin")]
public class SystemSettingController : Controller
{
    private readonly ISystemSettingService _service;

    public SystemSettingController(ISystemSettingService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var settings = await _service.GetAllAsync();
        return View(settings);
    }

    public async Task<IActionResult> Edit(string key)
    {
        var setting = await _service.GetByKeyAsync(key);
        if (setting == null) return NotFound();
        return View(setting);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(SystemSettingModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _service.AddOrUpdateAsync(model);
        return RedirectToAction("Index");
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(SystemSettingModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _service.AddOrUpdateAsync(model);
        return RedirectToAction("Index");
    }
}
