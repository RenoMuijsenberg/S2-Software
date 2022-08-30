using AModelLayer.Models;

namespace DALInterfaces.Interfaces;

public interface IScheme
{
    Task<List<SchemeModel>> GetSchemesByUser(string userId);
    Task<SchemeModel> GetSchemeById(int id);
}