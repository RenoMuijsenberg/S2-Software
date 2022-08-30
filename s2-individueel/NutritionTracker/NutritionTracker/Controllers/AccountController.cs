using AModelLayer.Models;
using LOGICinterface.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WEB_APP.Controllers;

public class AccountController : Controller
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    //Return register screen
    public IActionResult Index()
    {
        if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(AppUserModel user)
    {
        var result = await _userService.RegisterUser(user);

        if (!result.success)
        {
            TempData["Error"] = result.userMessage;

            return RedirectToAction("Index");
        }

        TempData["Success"] = result.userMessage;

        return RedirectToAction("Index", "Home");
    }

    //Return login screen
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(AppUserModel user)
    {
        var result = await _userService.LoginUser(user, user.IsPresistent);

        if (!result.success)
        {
            TempData["Error"] = result.userMessage;

            return View(user);
        }

        TempData["Success"] = result.userMessage;

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Logout()
    {
        var result = await _userService.LogoutUser();

        if (!result.success) TempData["Error"] = result.userMessage;

        TempData["Success"] = result.userMessage;

        return RedirectToAction("Login");
    }
}