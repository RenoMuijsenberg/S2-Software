using AModelLayer.Models;

namespace NutritionTracker.Models;

public class HomeView
{
    public SchemeModel Scheme { get; set; }
    public UserInfoModel UserInfo { get; set; }
    public List<EatenTodayModel> Eaten { get; set; }
}