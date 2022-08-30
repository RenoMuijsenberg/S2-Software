using AModelLayer.Models;
using DAL.Functions.Specific.UserInfo;
using DALInterfaces.Interfaces;
using LOGIC.Services.Models;
using LOGICinterface.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LOGIC.Services.Implementation;

public class UserInfoService : IUserInfoService
{
    private readonly IUserInfo _userInfo;

    public UserInfoService(IUserInfo userInfo)
    {
        _userInfo = userInfo;
    }

    public async Task<GenericResult<UserInfoModel>> GetUserInfo(string userId)
    {
        var result = new GenericResult<UserInfoModel>();
        try
        {
            var dalResult = await _userInfo.GetUserInfo(userId);

            result.result = dalResult;
            result.success = true;
        }
        catch (Exception exception)
        {
            result.exception = exception;
        }

        return result;
    }

    public async Task<GenericResult<UserInfoModel>> UpdateUserInfo(UserInfoModel model)
    {
        var result = new GenericResult<UserInfoModel>();
        try
        {
            var age = DateTime.Now.Subtract(model.BirthDate).Days / 365;

            if (model.Gender.ToLower() == "male")
            {
                model.RecommendedKcal = Convert.ToInt32((10 * model.Weight + 6.25 * model.Height - 5 * age + 5) * 1.55);
                model.RecommendedProtein = Convert.ToInt32(1.6 * model.Weight);
            }
            else
            {
                model.RecommendedKcal =
                    Convert.ToInt32((10 * model.Weight + 6.25 * model.Height - 5 * age - 161) * 1.55);
                model.RecommendedProtein = Convert.ToInt32(1.4 * model.Weight);
            }

            switch (model.Method)
            {
                case "Bulk":
                    model.RecommendedKcal = Convert.ToInt32(model.RecommendedKcal * 1.2);
                    break;
                case "Cut":
                    model.RecommendedKcal = Convert.ToInt32(model.RecommendedKcal * 0.8);
                    break;
            }

            var dalResult = await _userInfo.UpdateUserInfo(model);

            result.result = dalResult;
            result.userMessage = "Successfully updated user info";
            result.success = true;
        }
        catch (Exception exception)
        {
            result.exception = exception;
            result.userMessage = "Updating user info was not successfull";
        }

        return result;
    }
}