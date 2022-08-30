using AModelLayer.Models;
using LOGIC.Services.Models;

namespace LOGICinterface.Interfaces;

public interface ISchemeService
{
    Task<GenericResult<List<SchemeModel>>> GetSchemesByUserId(string userId);
    Task<GenericResult<SchemeModel>> GetSchemeById(int id);
    Task<GenericResult<SchemeModel>> CreateScheme(SchemeModel scheme);
    Task<GenericResult<SchemeModel>> UpdateScheme(SchemeModel scheme);
    Task<StandardResult> DeleteScheme(int id);
}