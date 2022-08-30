using AModelLayer.Models;
using LOGICinterface.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WEB_APP.Controllers;

public class SchemeController : Controller
{
    private readonly ISchemeService _schemeService;
    private readonly UserManager<IdentityUser> _userManager;

    public SchemeController(ISchemeService schemeService, UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
        _schemeService = schemeService;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var result = await _schemeService.GetSchemesByUserId(_userManager.GetUserId(User));

        return View(result.result);
    }

    public IActionResult CreateScheme()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateScheme(SchemeModel model)
    {
        var result = await _schemeService.CreateScheme(model);

        if (!result.success)
        {
            TempData["Error"] = result.userMessage;
            return View(model);
        }

        TempData["Success"] = result.userMessage;
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> EditScheme(int id)
    {
        var result = await _schemeService.GetSchemeById(id);

        return View(result.result);
    }

    [HttpPost]
    public async Task<IActionResult> EditScheme(SchemeModel scheme)
    {
        var result = await _schemeService.UpdateScheme(scheme);

        if (!result.success)
        {
            TempData["Error"] = result.userMessage;
            return View(scheme);
        }

        TempData["Success"] = result.userMessage;
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> SchemeDetail(int id)
    {
        var result = await _schemeService.GetSchemeById(id);

        return View(result.result);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteScheme(int id)
    {
        var result = await _schemeService.DeleteScheme(id);

        if (!result.success)
        {
            TempData["Error"] = result.userMessage;
            return RedirectToAction("Index");
        }

        TempData["Success"] = result.userMessage;
        return RedirectToAction("Index");
    }
}