using DAL.DataContext;
using DALInterfaces.Interfaces;
using Microsoft.AspNetCore.Identity;
using AModelLayer.Models;

namespace DAL.Functions.Specific.UserInfo;

public class UserInfo : IUserInfo
{
    private readonly DatabaseContext _db;

    public UserInfo(DatabaseContext db)
    {
        _db = db;
    }

    public async Task<UserInfoModel> GetUserInfo(string userId)
    {
        var userInfo = _db.UserInfos.First(x => x.UserId == userId);
        return userInfo;
    }

    public async Task<UserInfoModel> UpdateUserInfo(UserInfoModel model)
    {
        try
        {
            _db.UserInfos.Update(model);
            await _db.SaveChangesAsync();
            return model;
        }
        catch
        {
            throw;
        }
    }
}