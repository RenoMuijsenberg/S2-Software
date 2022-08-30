using AModelLayer.Models;
using LOGICinterface.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WEB_APP.Controllers;

public class SetController : Controller
{
    private readonly ISetService _setService;

    public SetController(ISetService setService)
    {
        _setService = setService;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(int id, SetModel set)
    {
        var result = await _setService.CreateSet(set, id);

        if (!result.success)
        {
            TempData["Error"] = result.userMessage;
            return View(set);
        }

        TempData["Success"] = result.userMessage;
        return RedirectToAction("ExcersiseDetail", "Excersise", new {id = set.ExceriseId});
    }

    public async Task<IActionResult> EditSet(int id)
    {
        var result = await _setService.GetSet(id);

        return View(result.result);
    }

    [HttpPost]
    public async Task<IActionResult> EditSet(SetModel set)
    {
        var result = await _setService.UpdateSet(set);

        if (!result.success)
        {
            TempData["Error"] = result.userMessage;
            return View(set);
        }

        TempData["Success"] = result.userMessage;
        return RedirectToAction("ExcersiseDetail", "Excersise", new {id = set.ExceriseId});
    }

    [HttpPost]
    public async Task<IActionResult> DeleteSet(int id)
    {
        var result = await _setService.DeleteSet(id);

        if (!result.success)
        {
            TempData["Error"] = result.userMessage;
            return RedirectToAction("Index", "Scheme");
        }

        TempData["Success"] = result.userMessage;
        return RedirectToAction("Index", "Scheme");
    }
}