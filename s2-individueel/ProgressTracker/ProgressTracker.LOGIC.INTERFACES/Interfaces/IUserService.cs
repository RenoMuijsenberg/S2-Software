using Microsoft.AspNetCore.Identity;
using ProgressTracker.MODEL.Models;
using ProgressTracker.MODEL.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTracker.LOGIC.INTERFACES.Interfaces
{
    public interface IUserService
    {
        Task<StandardResult> RegisterUser(AppUser registerUser);
        Task<GenericResult<IdentityUser>> LoginUser(AppUser loginUser);
    }
}
