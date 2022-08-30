using AModelLayer.Models;
using LOGIC.Services.Models;

namespace LOGICinterface.Interfaces;

public interface IUserInfoService
{
    Task<GenericResult<UserInfoModel>> GetUserInfo(string userId);
    Task<GenericResult<UserInfoModel>> UpdateUserInfo(UserInfoModel model);
}