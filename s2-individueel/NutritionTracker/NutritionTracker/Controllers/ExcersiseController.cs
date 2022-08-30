using AModelLayer.Models;
using LOGICinterface.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WEB_APP.Controllers;

public class ExcersiseController : Controller
{
    private readonly IExcersiseService _excersiseService;

    public ExcersiseController(IExcersiseService excersiseService)
    {
        _excersiseService = excersiseService;
    }

    // GET
    public async Task<IActionResult> CreateExcersise(int id)
    {
        TempData["SchemeId"] = id;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateExcersise(ExcersiseModel excersise)
    {
        var result = await _excersiseService.CreateExcersise(excersise);

        if (!result.success)
        {
            TempData["Error"] = result.userMessage;
            return RedirectToAction("Index", "Scheme");
        }

        TempData["Success"] = result.userMessage;
        return RedirectToAction("Index", "Scheme");
    }

    public async Task<IActionResult> EditExcersise(int id)
    {
        var result = await _excersiseService.GetExcersise(id);

        return View(result.result);
    }

    [HttpPost]
    public async Task<IActionResult> EditExcersise(ExcersiseModel excersise)
    {
        var result = await _excersiseService.UpdateExcersise(excersise);

        if (!result.success)
        {
            TempData["Error"] = result.userMessage;
            return RedirectToAction("Index", "Scheme");
        }

        TempData["Success"] = result.userMessage;
        return RedirectToAction("Index", "Scheme");
    }

    public async Task<IActionResult> ExcersiseDetail(int id)
    {
        var result = await _excersiseService.GetExcersise(id);

        return View(result.result);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteExcersise(int id)
    {
        var result = await _excersiseService.DeleteExcersise(id);

        if (!result.success)
        {
            TempData["Error"] = result.userMessage;
            return RedirectToAction("Index", "Scheme");
        }

        TempData["Success"] = result.userMessage;
        return RedirectToAction("Index", "Scheme");
    }
}