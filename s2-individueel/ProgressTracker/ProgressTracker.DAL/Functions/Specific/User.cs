using DAL.DataContext;
using Microsoft.AspNetCore.Identity;
using ProgressTracker.DAL.INTERFACES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTracker.DAL.Functions.Specific
{
    public class User : IUser
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly DatabaseContext _db;

        public User(UserManager<Microsoft.AspNetCore.Identity.IdentityUser> userManager, DatabaseContext db)
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

                return true;
            }
            catch
            {
                throw;

            }
        }

        public async Task<IdentityUser> FindUserByEmail(string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);

                return user;
            }
            catch
            {
                throw;
            }
        }
    }
}
