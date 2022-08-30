using DALInterfaces.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DAL.Functions.Specific.IdentityUser;

public class Role : IRole
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public Role(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<bool> CheckIfRoleExists(string roleName)
    {
        try
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }
        catch
        {
            throw;
        }
    }
    
    public async Task<bool> CreateNewRole(IdentityRole role)
    {
        try
        {
            var success = await _roleManager.CreateAsync(role);

            if (!success.Succeeded)
            {
                return false;
            }

            return true;
        }
        catch
        {
            throw;
        }
    }
}