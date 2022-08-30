using AModelLayer.Models;
using LOGIC.Services.Models;
using Microsoft.AspNetCore.Identity;

namespace LOGICinterface.Interfaces;

public interface IRoleService
{
    //Get all roles
    GenericResult<List<IdentityRole>> GetAllRoles();

    //Get signle role
    Task<GenericResult<IdentityRole>> GetSingleRole(string id);

    //Create role
    Task<GenericResult<IdentityRole>> CreateRole(string roleName);

    //Get all users in role with name
    Task<GenericResult<List<string>>> GetAllUsersInRole(string roleName);

    //Update role
    Task<GenericResult<IdentityRole>> UpdateRole(string roleId, string roleName);
    Task<GenericResult<List<AppUserModel>>> GetUserInRoleStatus(string roleId);
    Task<GenericResult<bool>> EditUserInRoleStatus(List<AppUserModel> model, string roleId);
}