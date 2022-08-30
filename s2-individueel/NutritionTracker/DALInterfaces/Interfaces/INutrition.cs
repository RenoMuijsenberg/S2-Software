using AModelLayer.Models;

namespace DALInterfaces.Interfaces;

public interface INutrition
{
    Task<List<NutritionModel>> GetNutritionWithDate(DateTime date, string userId);
}