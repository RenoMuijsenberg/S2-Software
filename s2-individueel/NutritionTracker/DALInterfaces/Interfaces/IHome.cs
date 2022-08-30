using AModelLayer.Models;

namespace DALInterfaces.Interfaces;

public interface IHome
{
    Task<SchemeModel> GetSchemesByUserAndDay(string userId, string today);
}