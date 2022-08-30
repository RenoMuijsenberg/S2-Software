using AModelLayer.Models;
using DALInterfaces.Interfaces;
using LOGIC.Services.Models;
using LOGICinterface.Interfaces;

namespace LOGIC.Services.Implementation;

public class NutritionService : INutritionService
{
    private readonly ICrud _crud;
    private readonly INutrition _nutrition;

    public NutritionService(ICrud crud, INutrition nutrition)
    {
        _crud = crud;
        _nutrition = nutrition;
    }

    public async Task<GenericResult<NutritionModel>> AddNutritionForToday(NutritionModel nutrition, string userId)
    {
        var result = new GenericResult<NutritionModel>();
        try
        {
            nutrition.UserId = userId;
            nutrition.Date = DateTime.Now;

            await _crud.Create(nutrition);

            result.userMessage = "Product was added successfully!";
            result.result = nutrition;
            result.success = true;
        }
        catch
        {
            result.userMessage = "Product was not added successfully, please try again.";
            result.success = false;
        }

        return result;
    }

    public async Task<GenericResult<List<NutritionModel>>> GetNutritionWithDate(DateTime date, string userid)
    {
        var result = new GenericResult<List<NutritionModel>>();
        try
        {
            var dalResult = await _nutrition.GetNutritionWithDate(date, userid);

            result.result = dalResult;
            result.success = true;
        }
        catch
        {
            result.success = false;
        }

        return result;
    }

    public async Task<GenericResult<List<EatenTodayModel>>> GetEatenToday(List<NutritionModel> nutrition, string userId)
    {
        var result = new GenericResult<List<EatenTodayModel>>();
        try
        {
            var eatenToday = new List<EatenTodayModel>();

            foreach (var eaten in nutrition)
            {
                var product = await _crud.Read<ProductModel>(eaten.ProductId);
                eatenToday.Add(new EatenTodayModel
                {
                    NutritionId = eaten.Id,
                    UserId = userId,
                    Name = product.Name,
                    Amount = eaten.Amount,
                    Calorie = product.Calorie * eaten.Amount,
                    Fat = product.Fat * eaten.Amount,
                    Carb = product.Calorie * eaten.Amount,
                    Protein = product.Protein * eaten.Amount,
                    Sugar = product.Sugar * eaten.Amount,
                    Salt = product.Salt * eaten.Amount
                });
            }

            result.success = true;
            result.result = eatenToday;
        }
        catch
        {
            result.success = false;
        }

        return result;
    }

    public async Task<StandardResult> DeleteNutrition(int id)
    {
        var result = new StandardResult();
        try
        {
            result.success = await _crud.Delete<NutritionModel>(id);
            result.userMessage = "Deleted successfully.";
        }
        catch (Exception exception)
        {
            result.exception = exception;
            result.userMessage = "Delete was not successfull.";
        }

        return result;
    }
}