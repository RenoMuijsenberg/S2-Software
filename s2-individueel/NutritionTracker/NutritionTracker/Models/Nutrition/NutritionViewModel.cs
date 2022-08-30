using AModelLayer.Models;

namespace NutritionTracker.Models.Nutrition;

public class NutritionViewModel
{
    public AModelLayer.Models.NutritionModel Nutrition { get; set; }
    public UserInfoModel UserInfo { get; set; }
    public IEnumerable<ProductModel> Products { get; set; }
    public IEnumerable<EatenTodayModel> Eaten { get; set; }
}