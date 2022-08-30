using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgressTracker.MODEL.Models
{
    public class AppUser : IdentityUser
    {
        [NotMapped] public string Password { get; set; }
        [NotMapped] public string ConfirmPassword { get; set; }
    }
}
