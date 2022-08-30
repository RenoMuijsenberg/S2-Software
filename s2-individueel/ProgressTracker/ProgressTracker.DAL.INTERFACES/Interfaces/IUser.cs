using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTracker.DAL.INTERFACES.Interfaces
{
    public interface IUser
    {
        Task<bool> RegisterUser(IdentityUser user, string password);
        Task<IdentityUser> FindUserByEmail(string email);
    }
}
