using AModelLayer.Models;
using LOGIC.Services.Models;

namespace LOGICinterface.Interfaces;

public interface ISetService
{
    Task<GenericResult<SetModel>> CreateSet(SetModel set, int excersiseId);
    Task<GenericResult<SetModel>> GetSet(int id);
    Task<GenericResult<SetModel>> UpdateSet(SetModel set);
    Task<StandardResult> DeleteSet(int id);
}