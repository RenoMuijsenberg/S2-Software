using Microsoft.AspNetCore.Identity;
using ProgressTracker.DAL.INTERFACES.Interfaces;
using ProgressTracker.LOGIC.INTERFACES.Interfaces;
using ProgressTracker.MODEL.Models;
using ProgressTracker.MODEL.Models.Result;

namespace ProgressTracker.LOGIC.Services
{
    public class UserService : IUserService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUser _user;

        public UserService(SignInManager<IdentityUser> signInManager, IUser user)
        {
            _signInManager = signInManager;
            _user = user;   
        }

        public async Task<StandardResult> RegisterUser(AppUser registerUser)
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

        public async Task<GenericResult<IdentityUser>> LoginUser(AppUser loginUser)
        {
            var result = new GenericResult<IdentityUser>();
            try
            {
                var user = await _user.FindUserByEmail(loginUser.Email);

                var singinResult = await _signInManager.PasswordSignInAsync(user, loginUser.Password, false, false);

                if (singinResult.Succeeded == true)
                {
                    result.success = true;
                    result.result = user;
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
    }
}
