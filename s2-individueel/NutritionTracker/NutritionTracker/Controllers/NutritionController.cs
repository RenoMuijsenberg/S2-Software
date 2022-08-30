using AModelLayer.Models;
using LOGICinterface.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NutritionTracker.Models;
using NutritionTracker.Models.Nutrition;

namespace WEB_APP.Controllers;

public class NutritionController : Controller
{
    private readonly INutritionService _nutritionService;
    private readonly IProductService _productService;
    private readonly IUserInfoService _userInfoService;
    private readonly UserManager<IdentityUser> _userManager;

    public NutritionController(IUserInfoService userInfoService, IProductService productService,
        UserManager<IdentityUser> userManager, INutritionService nutritionService)
    {
        _productService = productService;
        _userInfoService = userInfoService;
        _userManager = userManager;
        _nutritionService = nutritionService;
    }

    public async Task<IActionResult> Index()
    {
        var viewModel = new NutritionViewModel
        {
            UserInfo = _userInfoService.GetUserInfo(_userManager.GetUserId(User)).Result.result,
            Products = _productService.GetAllProducts().Result.result,
            Eaten = RetrieveNutrition(DateTime.Today.Date)
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Index(NutritionModel nutrition)
    {
        var result = await _nutritionService.AddNutritionForToday(nutrition, _userManager.GetUserId(User));

        if (result.success)
        {
            TempData["Success"] = result.userMessage; //Show message that product is created
            return RedirectToAction("Index"); //Return to product overview
        }

        TempData["Error"] = result.userMessage; //Show message that product is created
        return RedirectToAction("Index"); //Return to create view when not successfull
    }

    public List<EatenTodayModel> RetrieveNutrition(DateTime date)
    {
        var nutritionToday =
            _nutritionService.GetNutritionWithDate(date, _userManager.GetUserId(User));

        var eatenToday = _nutritionService.GetEatenToday(nutritionToday.Result.result, _userManager.GetUserId(User));


        return eatenToday.Result.result;
    }

    [HttpPost]
    public IActionResult UpdateTable(IFormCollection form)
    {
        var date = DateTime.Parse(form["date"]);
        
        var model = new NutritionViewModel
        {
            UserInfo = _userInfoService.GetUserInfo(_userManager.GetUserId(User)).Result.result,
            Eaten = RetrieveNutrition(date)
        };

        return PartialView("_TablePartialView", model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _nutritionService.DeleteNutrition(id);

        if (result.success)
        {
            TempData["Success"] = result.userMessage; //Show message that product is created
            return RedirectToAction("Index"); //Return to product overview
        }

        TempData["Error"] = result.userMessage; //Show message that product is created
        return RedirectToAction("Index"); //Return to create view when not successfull
    }
}