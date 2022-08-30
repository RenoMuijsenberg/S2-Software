using DAL.DataContext;
using DALInterfaces.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DAL.Functions.Specific.IdentityUser;

public class IdentityUser : IIdentityUser
{
    private readonly UserManager<Microsoft.AspNetCore.Identity.IdentityUser> _userManager;
    private readonly DatabaseContext _db;

    public IdentityUser(UserManager<Microsoft.AspNetCore.Identity.IdentityUser> userManager, DatabaseContext db)
    {
        _userManager = userManager;
        _db = db;
    }

    public async Task<bool> RegisterUser(Microsoft.AspNetCore.Identity.IdentityUser user, string password)
    {
        try
        {
            var result = await _userManager.CreateAsync(user, password);
            
            if (!result.Succeeded)
            {
                return false;
            }
            
            AModelLayer.Models.UserInfoModel userInfo = new AModelLayer.Models.UserInfoModel
            {
                UserId = user.Id
            };

            _db.UserInfos.Add(userInfo);
            await _db.SaveChangesAsync();

            return true;
        }
        catch
        {
            throw;
        }
    }

    public async Task<bool> AddUserToRole(Microsoft.AspNetCore.Identity.IdentityUser user, string roleName)
    {
        try
        {
            var result = await _userManager.AddToRoleAsync(user, roleName);

            if (!result.Succeeded)
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