using Microsoft.AspNetCore.Identity;

namespace DALInterfaces.Interfaces;

public interface IIdentityUser
{
    Task<bool> RegisterUser(IdentityUser user, string password);
    Task<bool> AddUserToRole(IdentityUser user, string roleName);
}