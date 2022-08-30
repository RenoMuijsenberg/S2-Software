using LOGICinterface.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NutritionTracker.Models;

namespace WEB_APP.Controllers;

public class HomeController : Controller
{
    private readonly IHomeService _homeService;
    private readonly INutritionService _nutritionService;
    private readonly IUserInfoService _userInfoService;
    private readonly UserManager<IdentityUser> _userManager;

    public HomeController(IHomeService homeService, UserManager<IdentityUser> userManager,
        INutritionService nutritionService, IUserInfoService userInfoService)
    {
        _userManager = userManager;
        _homeService = homeService;
        _nutritionService = nutritionService;
        _userInfoService = userInfoService;
    }

    [Authorize]
    public async Task<IActionResult> Index()
    {
        var schemeResult = await _homeService.GetSingleScheme(_userManager.GetUserId(User));
        var nutritionResult = await _nutritionService.GetNutritionWithDate(DateTime.Now, _userManager.GetUserId(User));
        var eatenResult = await _nutritionService.GetEatenToday(nutritionResult.result, _userManager.GetUserId(User));
        var userInfoResult = await _userInfoService.GetUserInfo(_userManager.GetUserId(User));

        var homeView = new HomeView
        {
            UserInfo = userInfoResult.result,
            Scheme = schemeResult.result,
            Eaten = eatenResult.result
        };

        return View(homeView);
    }
}