using LOGIC.Services.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AModelLayer.Models;

namespace LOGICinterface.Interfaces;

public interface IUserService
{
    Task<StandardResult> RegisterUser(AppUserModel registerUser);
    Task<StandardResult> LoginUser(AppUserModel user, bool remember);
    Task<StandardResult> LogoutUser();
}