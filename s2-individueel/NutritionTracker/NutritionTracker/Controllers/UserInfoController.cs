using AModelLayer.Models;
using LOGIC.Services.Implementation;
using LOGIC.Services.Models;
using LOGICinterface.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WEB_APP.Controllers;

public class UserInfoController : Controller
{
    private IUserInfoService _userInfoService;
    private UserManager<IdentityUser> _userManager;

    public UserInfoController(IUserInfoService userInfoService, UserManager<IdentityUser> userManager)
    {
        _userInfoService = userInfoService;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _userInfoService.GetUserInfo(_userManager.GetUserId(User));

        return View(result.result);
    }

    public async Task<IActionResult> Edit()
    {
        var result = await _userInfoService.GetUserInfo(_userManager.GetUserId(User));

        return View(result.result);
    }

    [HttpPost]
    public async Task<IActionResult> EditUserInfo(UserInfoModel model)
    {
        var result = await _userInfoService.UpdateUserInfo(model);

        if (!result.success)
        {
            TempData["Error"] = result.userMessage;
            return View("Edit", model);
        }

        TempData["Success"] = result.userMessage;
        return RedirectToAction("Index");
    }
}