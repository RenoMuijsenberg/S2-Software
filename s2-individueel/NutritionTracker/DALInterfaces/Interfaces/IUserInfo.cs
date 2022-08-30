using AModelLayer.Models;

namespace DALInterfaces.Interfaces;

public interface IUserInfo
{
    Task<UserInfoModel> GetUserInfo(string userId);
    Task<UserInfoModel> UpdateUserInfo(UserInfoModel model);
}