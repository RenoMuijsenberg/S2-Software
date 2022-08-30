using AModelLayer.Models;
using DALInterfaces.Interfaces;
using LOGIC.Services.Models;
using LOGICinterface.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace LOGIC.Services.Implementation;

public class UserService : IUserService
{
    private readonly IIdentityUser _user;
    private readonly IRole _role;
    private readonly SignInManager<IdentityUser> _signInManager;


    public UserService(IIdentityUser user, IRole role, SignInManager<IdentityUser> signInManager)
    {
        _user = user;
        _role = role;
        _signInManager = signInManager;
    }

    public async Task<StandardResult> RegisterUser(AppUserModel registerUser)
    {
        var result = new StandardResult();
        try
        {
            var user = new IdentityUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email
            };

            if (await _user.RegisterUser(user, registerUser.Password))
            {
                if (!await _role.CheckIfRoleExists("User"))
                {
                    var role = new IdentityRole
                    {
                        Name = "User"
                    };

                    if (await _role.CreateNewRole(role)) await _user.AddUserToRole(user, "User");
                }
                else
                {
                    await _user.AddUserToRole(user, "User");
                }

                await _signInManager.SignInAsync(user, false);
            }

            result.success = true;
            result.userMessage = string.Format("Successfully registerd!");
        }
        catch (Exception exception)
        {
            result.exception = exception;
            result.userMessage = string.Format("Unsuccessfully registerd.");
        }

        return result;
    }

    public async Task<StandardResult> LoginUser(AppUserModel user, bool remember)
    {
        var result = new StandardResult();
        try
        {
            var signIn = await _signInManager.PasswordSignInAsync(user.Email, user.Password, remember, false);

            if (signIn.Succeeded)
            {
                result.success = true;
                result.userMessage = string.Format("Successfully logged in!");
            }
            else
            {
                result.userMessage = string.Format("Unsuccessfully logged in.");
            }
        }
        catch (Exception exception)
        {
            result.exception = exception;
            result.userMessage = string.Format("Unsuccessfully logged in.");
        }

        return result;
    }

    public async Task<StandardResult> LogoutUser()
    {
        var result = new StandardResult();
        try
        {
            await _signInManager.SignOutAsync();

            result.success = true;
            result.userMessage = string.Format("Successfully logged out!");
        }
        catch (Exception exception)
        {
            result.exception = exception;
            result.userMessage = string.Format("Unsuccessfully logged out.");
        }

        return result;
    }
}