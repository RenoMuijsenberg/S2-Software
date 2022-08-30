using AModelLayer.Models;
using LOGIC.Services.Models;

namespace LOGICinterface.Interfaces;

public interface IHomeService
{
    Task<GenericResult<SchemeModel>> GetSingleScheme(string userId);
}