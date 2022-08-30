using AModelLayer.Models;
using LOGICinterface.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NutritionTracker.Models.Role;

namespace WEB_APP.Controllers;

public class RoleController : Controller
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public IActionResult Index()
    {
        var result = _roleService.GetAllRoles();

        return View(result.result);
    }

    public async Task<IActionResult> CreateRole()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole(RoleViewModel model)
    {
        var result = await _roleService.CreateRole(model.RoleName);

        if (!result.success)
        {
            TempData["Error"] = result.userMessage;
            return View(model);
        }

        TempData["Success"] = result.userMessage;
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> EditRole(string id)
    {
        var result = await _roleService.GetSingleRole(id);

        var role = new EditViewRoleModel
        {
            Id = result.result.Id,
            RoleName = result.result.Name
        };

        var getUsersResult = await _roleService.GetAllUsersInRole(result.result.Name);

        role.Users = getUsersResult.result;

        return View(role);
    }

    [HttpPost]
    public async Task<IActionResult> EditRole(EditViewRoleModel model)
    {
        var result = await _roleService.UpdateRole(model.Id, model.RoleName);

        if (!result.success)
        {
            TempData["error"] = result.userMessage;
            return View(model);
        }

        TempData["success"] = result.userMessage;
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> EditUsersInRole(string roleId)
    {
        ViewBag.RoleId = roleId;

        var result = await _roleService.GetUserInRoleStatus(roleId);

        List<AppUserModel> model = new();

        foreach (var userHasRole in result.result) model.Add(userHasRole);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EditUsersInRole(List<AppUserModel> model, string roleId)
    {
        var result = await _roleService.EditUserInRoleStatus(model, roleId);

        if (!result.success)
        {
            TempData["Error"] = result.userMessage;
            return View(model);
        }

        TempData["Success"] = result.userMessage;
        return RedirectToAction("Index");
    }
}