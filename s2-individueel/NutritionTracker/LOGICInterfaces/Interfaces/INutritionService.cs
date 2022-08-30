using AModelLayer.Models;
using LOGIC.Services.Models;

namespace LOGICinterface.Interfaces;

public interface INutritionService
{
    Task<GenericResult<NutritionModel>> AddNutritionForToday(NutritionModel nutrition, string userId);
    Task<GenericResult<List<NutritionModel>>> GetNutritionWithDate(DateTime date, string userid);
    Task<GenericResult<List<EatenTodayModel>>> GetEatenToday(List<NutritionModel> nutrition, string userId);
    Task<StandardResult> DeleteNutrition(int id);
}