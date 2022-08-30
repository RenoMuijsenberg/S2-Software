using System.ComponentModel.DataAnnotations;

namespace NutritionTracker.Models.Role
{
    public class RoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
