using Microsoft.AspNetCore.Identity;

namespace DALInterfaces.Interfaces;


public interface IRole
{
    Task<bool> CheckIfRoleExists(string roleName);
    Task<bool> CreateNewRole(IdentityRole role);
}