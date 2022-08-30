using AModelLayer.Models;
using LOGIC.Services.Models;
using LOGICinterface.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace LOGIC.Services.Implementation;

public class RoleService : IRoleService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;

    public RoleService(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public GenericResult<List<IdentityRole>> GetAllRoles()
    {
        var result = new GenericResult<List<IdentityRole>>();
        try
        {
            result.result = _roleManager.Roles.ToList();
            result.success = true;
        }
        catch (Exception exception)
        {
            result.exception = exception;
        }

        return result;
    }

    public async Task<GenericResult<IdentityRole>> CreateRole(string roleName)
    {
        var result = new GenericResult<IdentityRole>();
        try
        {
            var identityRole = new IdentityRole
            {
                Name = roleName
            };

            var created = await _roleManager.CreateAsync(identityRole);

            result.result = identityRole;
            result.success = true;
            result.userMessage = string.Format("Role {0} was created successfully.", roleName);
        }
        catch (Exception exception)
        {
            result.exception = exception;
            result.userMessage = string.Format("Role {0} was not created successfully.", roleName);
        }

        return result;
    }

    public async Task<GenericResult<IdentityRole>> GetSingleRole(string id)
    {
        var result = new GenericResult<IdentityRole>();
        try
        {
            result.result = await _roleManager.FindByIdAsync(id);
            result.success = true;
        }
        catch (Exception exception)
        {
            result.exception = exception;
        }

        return result;
    }

    public async Task<GenericResult<List<string>>> GetAllUsersInRole(string roleName)
    {
        var result = new GenericResult<List<string>>();
        try
        {
            var users = await _userManager.Users.ToListAsync();
            var usersInRole = new List<string>();

            foreach (var user in users)
            {
                var userInRole = await _userManager.IsInRoleAsync(user, roleName);
                if (userInRole) usersInRole.Add(user.UserName);
            }

            result.success = true;
            result.result = usersInRole;
        }
        catch (Exception exception)
        {
            result.exception = exception;
        }

        return result;
    }

    public async Task<GenericResult<IdentityRole>> UpdateRole(string roleId, string roleName)
    {
        var result = new GenericResult<IdentityRole>();
        try
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            role.Name = roleName;

            await _roleManager.UpdateAsync(role);

            result.success = true;
            result.userMessage = string.Format("{0} was updated successfully.", roleName);
        }
        catch (Exception exception)
        {
            result.exception = exception;
        }

        return result;
    }

    public async Task<GenericResult<List<AppUserModel>>> GetUserInRoleStatus(string roleId)
    {
        var result = new GenericResult<List<AppUserModel>>();
        try
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            var userList = await _userManager.Users.ToListAsync();

            var userWithRole = new List<AppUserModel>();

            foreach (var user in userList)
            {
                var userHasRole = new AppUserModel
                {
                    Id = user.Id,
                    UserName = user.UserName
                };

                if (await _userManager.IsInRoleAsync(user, role.Name))
                    userHasRole.HasRole = true;
                else
                    userHasRole.HasRole = false;

                userWithRole.Add(userHasRole);
            }

            result.result = userWithRole;
            result.success = true;
        }
        catch (Exception exception)
        {
            result.exception = exception;
        }

        return result;
    }

    public async Task<GenericResult<bool>> EditUserInRoleStatus(List<AppUserModel> model, string roleId)
    {
        var result = new GenericResult<bool>();

        try
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            for (var i = 0; i < model.Count; i++)
            {
                var user = await _userManager.FindByIdAsync(model[i].Id);

                IdentityResult identityResult = null;

                if (model[i].HasRole && !await _userManager.IsInRoleAsync(user, role.Name))
                    identityResult = await _userManager.AddToRoleAsync(user, role.Name);
                else if (!model[i].HasRole && await _userManager.IsInRoleAsync(user, role.Name))
                    identityResult = await _userManager.RemoveFromRoleAsync(user, role.Name);
                else
                    continue;

                if (identityResult.Succeeded)
                    if (i < model.Count - 1)
                        continue;
            }

            result.success = true;
            result.result = true;
            result.userMessage = string.Format("Update user roles successfully.");
        }
        catch (Exception exception)
        {
            result.exception = exception;
            result.userMessage = string.Format("Did not update user roles successfully.");
        }

        return result;
    }
}