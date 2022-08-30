using System.ComponentModel.DataAnnotations;

namespace AModelLayer.Models;

public class UserInfoModel
{
    public int Id { get; set; } //PK
    public string UserId { get; set; } //FK
    public int Weight { get; set; }
    public int Height { get; set; }
    public DateTime BirthDate { get; set; }
    public string Method { get; set; }
    public string Gender { get; set; }
    public int RecommendedKcal { get; set; }
    public int RecommendedProtein { get; set; }
    
    //RELATIONS:
    //A UserInfo belong to 1 user.
    public AppUserModel User { get; set; }
}