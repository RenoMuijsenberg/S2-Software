using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AModelLayer.Models;

public class AppUserModel : IdentityUser
{
    //This needs to be inhereting from identity user but i need to find out how that will work in 3 tier
    [NotMapped]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [NotMapped]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }

    [NotMapped] public bool IsPresistent { get; set; }
    [NotMapped] public bool HasRole { get; set; }

    //RELATIONS
    //A user has 1 User info
    public UserInfoModel UserInfo { get; set; }

    //A User can have multiple scheme
    public ICollection<SchemeModel> Schemes { get; set; }

    //A user can have multiple nutritions
    public ICollection<NutritionModel> Nutritions { get; set; }
}